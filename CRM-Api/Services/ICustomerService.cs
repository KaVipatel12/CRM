using CRM_Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListDto>> GetHistoryListAsync(CustomerListFilter filter);
        Task<CustomerDetailsDto?> GetCustomerByIdAsync(int id);
        Task<int> CreateCustomerAsync(CustomerSaveDto dto);
        Task<bool> UpdateCustomerAsync(int id, CustomerSaveDto dto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<int> GetIncrementCodeByTypeAsync(int contactType);
        Task<bool> CheckDuplicateCodeAsync(string code);
        Task<IEnumerable<FileUploadInfoDto>> GetUploadHistoryAsync();
        Task<FileUploadInfoDto> ProcessFileAsync(int fileId);
        Task<bool> VerifyCustomerAsync(int id, int userId);
        Task<bool> MigrateCustomerTypeAsync(int customerId, int newClientType);
    }
}
