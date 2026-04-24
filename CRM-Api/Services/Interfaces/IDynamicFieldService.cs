using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface IDynamicFieldService
    {
        // Master Field Management
        Task<IEnumerable<DynamicFieldMasterDto>> GetMastersAsync();
        Task<DynamicFieldMasterDto> AddMasterAsync(CreateDynamicFieldMasterDto dto);
        Task<bool> UpdateMasterAsync(int id, CreateDynamicFieldMasterDto dto);
        Task<bool> DeleteMasterAsync(int id);

        // Customer Value Management
        Task<IEnumerable<DynamicFieldValueDto>> GetValuesByCustomerIdAsync(int customerId);
        Task<bool> UpsertValuesAsync(int customerId, IEnumerable<UpsertDynamicFieldValueDto> values);
    }
}
