using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.DynamicFields;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class DynamicFieldService : IDynamicFieldService
    {
        private readonly AppDbContext _context;

        public DynamicFieldService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DynamicFieldMasterDto>> GetMastersAsync()
        {
            return await _context.DynamicFieldMasters
                .Where(m => !m.IsDeleted && m.IsActive)
                .OrderBy(m => m.SortOrder)
                .Select(m => new DynamicFieldMasterDto
                {
                    Id = m.Id,
                    FieldName = m.FieldName,
                    DisplayName = m.DisplayName,
                    FieldType = m.FieldType,
                    FieldAbbreviation = m.FieldAbbreviation,
                    DefaultValue = m.DefaultValue,
                    Category = m.Category,
                    IsActive = m.IsActive,
                    SortOrder = m.SortOrder,
                    Options = m.Options,
                    DisplayTypeIds = m.DisplayTypeIds
                })
                .ToListAsync();
        }

        public async Task<DynamicFieldMasterDto> AddMasterAsync(CreateDynamicFieldMasterDto dto)
        {
            var master = new DynamicFieldMaster
            {
                FieldName = dto.FieldName,
                DisplayName = dto.DisplayName,
                FieldType = dto.FieldType,
                FieldAbbreviation = dto.FieldAbbreviation,
                DefaultValue = dto.DefaultValue,
                Category = dto.Category,
                Options = dto.Options,
                DisplayTypeIds = dto.DisplayTypeIds
            };

            _context.DynamicFieldMasters.Add(master);
            await _context.SaveChangesAsync();

            return new DynamicFieldMasterDto
            {
                Id = master.Id,
                FieldName = master.FieldName,
                DisplayName = master.DisplayName,
                FieldType = master.FieldType,
                FieldAbbreviation = master.FieldAbbreviation,
                DefaultValue = master.DefaultValue,
                Category = master.Category,
                IsActive = master.IsActive,
                SortOrder = master.SortOrder,
                Options = master.Options,
                DisplayTypeIds = master.DisplayTypeIds
            };
        }

        public async Task<bool> UpdateMasterAsync(int id, CreateDynamicFieldMasterDto dto)
        {
            var master = await _context.DynamicFieldMasters.FindAsync(id);
            if (master == null) return false;

            master.FieldName = dto.FieldName;
            master.DisplayName = dto.DisplayName;
            master.FieldType = dto.FieldType;
            master.FieldAbbreviation = dto.FieldAbbreviation;
            master.DefaultValue = dto.DefaultValue;
            master.Category = dto.Category;
            master.Options = dto.Options;
            master.DisplayTypeIds = dto.DisplayTypeIds;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMasterAsync(int id)
        {
            var master = await _context.DynamicFieldMasters.FindAsync(id);
            if (master == null) return false;

            master.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DynamicFieldValueDto>> GetValuesByCustomerIdAsync(int customerId)
        {
            return await _context.DynamicFieldValues
                .Where(v => v.CustomerId == customerId)
                .Include(v => v.FieldMaster)
                .Select(v => new DynamicFieldValueDto
                {
                    Id = v.Id,
                    CustomerId = v.CustomerId,
                    FieldId = v.FieldId,
                    FieldValue = v.FieldValue,
                    FieldDisplayName = v.FieldMaster != null ? v.FieldMaster.DisplayName : string.Empty
                })
                .ToListAsync();
        }

        public async Task<bool> UpsertValuesAsync(int customerId, IEnumerable<UpsertDynamicFieldValueDto> values)
        {
            foreach (var valDto in values)
            {
                var existingValue = await _context.DynamicFieldValues
                    .FirstOrDefaultAsync(v => v.CustomerId == customerId && v.FieldId == valDto.FieldId);

                if (existingValue != null)
                {
                    existingValue.FieldValue = valDto.FieldValue;
                }
                else
                {
                    _context.DynamicFieldValues.Add(new DynamicFieldValue
                    {
                        CustomerId = customerId,
                        FieldId = valDto.FieldId,
                        FieldValue = valDto.FieldValue
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
