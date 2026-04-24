using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Models.Entities.DynamicFields;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReportFieldDto>> GetAvailableFieldsAsync(int? clientType)
        {
            var fields = new List<ReportFieldDto>();

            // 1. Core Fields (Static Mapping)
            fields.AddRange(new[]
            {
                new ReportFieldDto { Key = "Name", DisplayName = "Client Name", Category = "General" },
                new ReportFieldDto { Key = "Code", DisplayName = "Client Code", Category = "General" },
                new ReportFieldDto { Key = "TradingName", DisplayName = "Trading Name", Category = "General" },
                new ReportFieldDto { Key = "ABNNumber", DisplayName = "ABN Number", Category = "General" },
                new ReportFieldDto { Key = "TFNNumber", DisplayName = "TFN Number", Category = "General" },
                new ReportFieldDto { Key = "MailingName", DisplayName = "Mailing Name", Category = "General" },
                new ReportFieldDto { Key = "FirmType", DisplayName = "Firm Type", Category = "General" },
                new ReportFieldDto { Key = "ClientFrom", DisplayName = "Client From", Category = "General" },
                new ReportFieldDto { Key = "Partner", DisplayName = "Partner", Category = "General" },
                new ReportFieldDto { Key = "Manager", DisplayName = "Manager", Category = "General" },
                new ReportFieldDto { Key = "TaxAgent", DisplayName = "Tax Agent", Category = "General" },
                new ReportFieldDto { Key = "Class", DisplayName = "Class", Category = "General" },
                new ReportFieldDto { Key = "BalanceDate", DisplayName = "Balance Date", Category = "General" },
                new ReportFieldDto { Key = "InBusinessSince", DisplayName = "In Business Since", Category = "General" },
                
                // Contact Details
                new ReportFieldDto { Key = "Email", DisplayName = "Email Address", Category = "Contact" },
                new ReportFieldDto { Key = "CellPhone", DisplayName = "Mobile Number", Category = "Contact" },
                new ReportFieldDto { Key = "HomePhone", DisplayName = "Home Phone", Category = "Contact" },
                new ReportFieldDto { Key = "WorkPhone", DisplayName = "Work Phone", Category = "Contact" },
                
                // Address (Default to Primary/Physical)
                new ReportFieldDto { Key = "AddressLine1", DisplayName = "Address Line 1", Category = "Address" },
                new ReportFieldDto { Key = "City", DisplayName = "City", Category = "Address" },
                new ReportFieldDto { Key = "State", DisplayName = "State", Category = "Address" },
                new ReportFieldDto { Key = "PostalCode", DisplayName = "Postcode", Category = "Address" }
            });

            // 2. Dynamic Fields from Master
            var dynamicMasters = await _context.DynamicFieldMasters
                .Where(m => !m.IsDeleted && m.IsActive)
                .ToListAsync();

            foreach (var master in dynamicMasters)
            {
                // Filter by clientType if provided
                if (clientType.HasValue)
                {
                    if (string.IsNullOrEmpty(master.DisplayTypeIds))
                    {
                        // If no mapping exists, don't show it for specific types
                        continue;
                    }
                    
                    var typeIds = master.DisplayTypeIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(s => s.Trim());
                    if (!typeIds.Contains(clientType.Value.ToString()))
                    {
                        continue;
                    }
                }

                fields.Add(new ReportFieldDto
                {
                    Key = $"df_{master.Id}",
                    DisplayName = master.DisplayName,
                    Category = master.Category ?? "Custom",
                    IsDynamic = true,
                    DynamicFieldId = master.Id
                });
            }

            return fields;
        }

        public async Task<byte[]> GenerateClientDetailsReportAsync(ClientDetailsReportFilter filter)
        {
            var query = _context.Customers
                .Include(c => c.ContactInfo)
                .Include(c => c.Addresses)
                .Include("DynamicFieldValues")
                .AsQueryable();

            // Apply Filters
            if (filter.ClientType.HasValue) query = query.Where(c => c.ClientType == filter.ClientType.Value);
            if (filter.ContactType.HasValue) query = query.Where(c => c.ContactType == filter.ContactType.Value);
            if (filter.PartnerId.HasValue)
            {
                // Join with CustomerRelationships to find customers who have this person as a partner
                var today = DateTime.Today;
                var sourceCustomerIds = await _context.CustomerRelationships
                    .Where(r => r.TargetCustomerId == filter.PartnerId.Value && !r.IsDeleted && (r.EndDate == null || r.EndDate >= today))
                    .Select(r => r.SourceCustomerId)
                    .Distinct()
                    .ToListAsync();
                
                query = query.Where(c => sourceCustomerIds.Contains(c.Id));
            }
            else if (!string.IsNullOrEmpty(filter.Partner)) 
            {
                var partnerSearch = filter.Partner.Trim().ToLower();
                query = query.Where(c => c.Partner != null && c.Partner.ToLower().Contains(partnerSearch));
            }
            // Base status filters
            if (filter.IsArchived.HasValue && filter.IsArchived.Value)
            {
                // If searching for archived, only show deleted records
                query = query.Where(c => c.IsDeleted == true);
            }
            else
            {
                // By default or if Archived is No, hide deleted records
                query = query.Where(c => c.IsDeleted == false);
            }

            if (filter.IsActive.HasValue)
            {
                if (filter.IsActive.Value) query = query.Where(c => c.IsActive == true);
                else query = query.Where(c => c.IsActive != true);
            }

            if (filter.IsExcluded.HasValue)
            {
                if (filter.IsExcluded.Value) query = query.Where(c => c.IsExcluded == true);
                else query = query.Where(c => c.IsExcluded != true);
            }
            if (filter.StaffInCharge.HasValue) query = query.Where(c => c.StaffInCharge == filter.StaffInCharge.Value);
            if (filter.TradingStatus.HasValue) query = query.Where(c => c.TradingStatus == filter.TradingStatus.Value);
            if (filter.SelectedCustomerIds != null && filter.SelectedCustomerIds.Any())
            {
                query = query.Where(c => filter.SelectedCustomerIds.Contains(c.Id));
            }

            // Fetch Data
            var customers = await query.ToListAsync();

            // Sorting (Simplistic)
            if (filter.OrderBy == "Name")
                customers = filter.OrderDirection == "DESC" ? customers.OrderByDescending(c => c.Name).ToList() : customers.OrderBy(c => c.Name).ToList();
            else if (filter.OrderBy == "Code")
                customers = filter.OrderDirection == "DESC" ? customers.OrderByDescending(c => c.Code).ToList() : customers.OrderBy(c => c.Code).ToList();

            // Build CSV
            var allAvailableFields = await GetAvailableFieldsAsync(null);
            var selectedFields = allAvailableFields.Where(f => filter.SelectedFieldKeys.Contains(f.Key)).ToList();

            // If no fields selected, default to Name and Code
            if (!selectedFields.Any())
            {
                selectedFields = allAvailableFields.Where(f => f.Key == "Name" || f.Key == "Code").ToList();
            }

            var sb = new StringBuilder();

            // Header
            sb.AppendLine(string.Join(",", selectedFields.Select(f => $"\"{f.DisplayName}\"")));

            // Rows
            foreach (var customer in customers)
            {
                var values = new List<string>();
                foreach (var field in selectedFields)
                {
                    string value = GetFieldValue(customer, field);
                    // Escape quotes for CSV
                    value = value?.Replace("\"", "\"\"") ?? "";
                    values.Add($"\"{value}\"");
                }
                sb.AppendLine(string.Join(",", values));
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private string GetFieldValue(CRM_Api.Models.Entities.Customer.Customer customer, ReportFieldDto field)
        {
            if (field.IsDynamic)
            {
                var dynVal = customer.DynamicFieldValues.FirstOrDefault(v => v.FieldId == field.DynamicFieldId);
                return dynVal?.FieldValue ?? "";
            }

            // Fixed Mapping
            return field.Key switch
            {
                "Name" => customer.Name,
                "Code" => customer.Code ?? "",
                "TradingName" => customer.TradingName ?? "",
                "ABNNumber" => customer.ABNNumber ?? "",
                "TFNNumber" => customer.TFNNumber ?? "",
                "MailingName" => customer.MailingName ?? "",
                "FirmType" => customer.FirmType ?? "",
                "ClientFrom" => customer.ClientFrom ?? "",
                "Partner" => customer.Partner ?? "",
                "Manager" => customer.Manager ?? "",
                "TaxAgent" => customer.TaxAgent ?? "",
                "Class" => customer.Class ?? "",
                "BalanceDate" => customer.BalanceDate ?? "",
                "InBusinessSince" => customer.InBusinessSince ?? "",
                "Email" => customer.ContactInfo?.Email ?? "",
                "CellPhone" => customer.ContactInfo?.CellPhone ?? "",
                "HomePhone" => customer.ContactInfo?.HomePhone ?? "",
                "WorkPhone" => customer.ContactInfo?.WorkPhone ?? "",
                "AddressLine1" => customer.Addresses.FirstOrDefault()?.AddressLine1 ?? "",
                "City" => customer.Addresses.FirstOrDefault()?.City ?? "",
                "State" => customer.Addresses.FirstOrDefault()?.State ?? "",
                "PostalCode" => customer.Addresses.FirstOrDefault()?.PostalCode ?? "",
                _ => ""
            };
        }

        public async Task<byte[]> GenerateFSNotesReportAsync(FSNotesReportFilter filter)
        {
            var query = _context.Customers
                .Include(c => c.FSNotes).ThenInclude(n => n.FSNoteMaster)
                .AsQueryable();

            // Filters (Consistent with Customer Listing)
            if (filter.ContactType.HasValue)
                query = query.Where(c => c.ContactType == filter.ContactType.Value);

            if (filter.ClientType.HasValue)
                query = query.Where(c => c.ClientType == filter.ClientType.Value);

            if (filter.StaffInCharge.HasValue)
                query = query.Where(c => c.StaffInCharge == filter.StaffInCharge.Value);

            if (filter.PartnerId.HasValue)
            {
                var today = DateTime.Today;
                var sourceCustomerIds = await _context.CustomerRelationships
                    .Where(r => r.TargetCustomerId == filter.PartnerId.Value && !r.IsDeleted && (r.EndDate == null || r.EndDate >= today))
                    .Select(r => r.SourceCustomerId)
                    .Distinct()
                    .ToListAsync();
                
                query = query.Where(c => sourceCustomerIds.Contains(c.Id));
            }
            else if (!string.IsNullOrEmpty(filter.Partner)) 
            {
                var partnerSearch = filter.Partner.Trim().ToLower();
                query = query.Where(c => c.Partner != null && c.Partner.ToLower().Contains(partnerSearch));
            }

            if (filter.IsActive.HasValue)
            {
                if (filter.IsActive.Value) query = query.Where(c => c.IsActive == true);
                else query = query.Where(c => c.IsActive != true);
            }

            if (filter.IsArchived == true)
                query = query.Where(c => c.IsDeleted == true);
            else
                query = query.Where(c => c.IsDeleted == false);

            if (filter.IsExcluded.HasValue)
            {
                if (filter.IsExcluded.Value) query = query.Where(c => c.IsExcluded == true);
                else query = query.Where(c => c.IsExcluded != true);
            }

            if (filter.SelectedCustomerIds != null && filter.SelectedCustomerIds.Any())
            {
                query = query.Where(c => filter.SelectedCustomerIds.Contains(c.Id));
            }

            // Fetch Data
            var customers = await query.ToListAsync();

            // Filter by Note Types if specified
         //   if (filter.SelectedNoteTypeIds != null && filter.SelectedNoteTypeIds.Any())
           // {
                // We keep only customers who have at least one note of the selected types, 
                // OR we filter the notes themselves later? 
                // Usually, report shows all customers matching filters, and their notes of selected types.
        // }

            // Sorting
            if (filter.OrderBy == "Name")
                customers = filter.OrderDirection == "DESC" ? customers.OrderByDescending(c => c.Name).ToList() : customers.OrderBy(c => c.Name).ToList();
            else
                customers = filter.OrderDirection == "DESC" ? customers.OrderByDescending(c => c.Code).ToList() : customers.OrderBy(c => c.Code).ToList();

            var sb = new StringBuilder();

            // Header: Code, Name, Note Type, Note Content
            sb.AppendLine("\"Client Code\",\"Client Name\",\"Note Type\",\"Note Content\"");

            foreach (var customer in customers)
            {
                var notes = customer.FSNotes.AsEnumerable();
                if (filter.SelectedNoteTypeIds != null && filter.SelectedNoteTypeIds.Any())
                {
                    notes = notes.Where(n => filter.SelectedNoteTypeIds.Contains(n.FSNoteMasterID));
                }

                if (!notes.Any()) continue; // Skip customers with no notes of the selected types

                foreach (var note in notes)
                {
                    string code = (customer.Code ?? "").Replace("\"", "\"\"");
                    string name = (customer.Name ?? "").Replace("\"", "\"\"");
                    string noteType = (note.FSNoteMaster?.NoteType ?? "Unknown").Replace("\"", "\"\"");
                    string content = (note.NoteContent ?? "").Replace("\"", "\"\"");

                    sb.AppendLine($"\"{code}\",\"{name}\",\"{noteType}\",\"{content}\"");
                }
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
