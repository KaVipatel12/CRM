using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class CustomerRelationshipService : ICustomerRelationshipService
    {
        private readonly AppDbContext _context;

        public CustomerRelationshipService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerRelationshipDto>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.CustomerRelationships
                .Where(r => (r.SourceCustomerId == customerId || r.TargetCustomerId == customerId) && !r.IsDeleted)
                .Select(r => new CustomerRelationshipDto
                {
                    Id = r.Id,
                    SourceCustomerId = r.SourceCustomerId,
                    TargetCustomerId = r.TargetCustomerId,
                    RelationshipTypeId = r.RelationshipTypeId,
                    RelationshipTypeName = r.RelationshipType != null ? r.RelationshipType.Name ?? "" : "",
                    TargetCustomerName = r.SourceCustomerId == customerId 
                        ? (r.TargetCustomer != null ? r.TargetCustomer.Name ?? "" : "")
                        : (r.SourceCustomer != null ? r.SourceCustomer.Name ?? "" : ""),
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    NoOfShare = r.NoOfShare,
                    Note = r.Note
                })
                .ToListAsync();
        }

        public async Task<List<LookupDto>> GetRelationshipTypesAsync()
        {
            return await _context.RelationShipTypes
                .Select(t => new LookupDto
                {
                    Id = t.ID,
                    Name = t.Name ?? ""
                })
                .ToListAsync();
        }

        public async Task<CustomerRelationshipDto> AddAsync(CreateCustomerRelationshipDto dto)
        {
            var relationship = new CustomerRelationship
            {
                SourceCustomerId = dto.SourceCustomerId,
                TargetCustomerId = dto.TargetCustomerId,
                RelationshipTypeId = dto.RelationshipTypeId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                NoOfShare = dto.NoOfShare,
                Note = dto.Note,
                IsDeleted = false
            };

            _context.CustomerRelationships.Add(relationship);
            await _context.SaveChangesAsync();

            // Load related data for the response
            var saved = await _context.CustomerRelationships
                .Include(r => r.TargetCustomer)
                .Include(r => r.RelationshipType)
                .FirstOrDefaultAsync(r => r.Id == relationship.Id);

            return new CustomerRelationshipDto
            {
                Id = saved!.Id,
                SourceCustomerId = saved.SourceCustomerId,
                TargetCustomerId = saved.TargetCustomerId,
                RelationshipTypeId = saved.RelationshipTypeId,
                RelationshipTypeName = saved.RelationshipType?.Name ?? "",
                TargetCustomerName = saved.TargetCustomer?.Name ?? "",
                StartDate = saved.StartDate,
                EndDate = saved.EndDate,
                NoOfShare = saved.NoOfShare,
                Note = saved.Note
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var relationship = await _context.CustomerRelationships.FindAsync(id);
            if (relationship == null) return false;

            relationship.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
