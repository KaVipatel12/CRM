using CRM_Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public interface ICustomerService
    {
        Task<CustomerPagedResponseDto> GetHistoryListAsync(CustomerListFilter filter);
        Task<CustomerStatisticsDto> GetStatisticsAsync();
        Task<CustomerDetailsDto?> GetCustomerByIdAsync(int id);
        Task<int> CreateCustomerAsync(CustomerSaveDto dto);
        Task<bool> UpdateCustomerAsync(int id, CustomerSaveDto dto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<int> GetIncrementCodeByTypeAsync(int contactType);
        Task<bool> CheckDuplicateCodeAsync(string code);
        Task<IEnumerable<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync(bool forceRefresh = false);
        Task<IEnumerable<FileUploadInfoDto>> GetUploadHistoryAsync();
        Task<FileUploadInfoDto> ProcessFileAsync(int fileId);
        Task<bool> VerifyCustomerAsync(int id, int userId);
        Task<bool> MigrateCustomerTypeAsync(int customerId, int newClientType);

        // Service Portfolio Methods
        Task<IEnumerable<ServiceMasterDto>> GetServiceMastersAsync();
        Task<IEnumerable<CustomerServiceDto>> GetCustomerServicesAsync(int customerId);
        Task<bool> UpsertCustomerServiceAsync(CustomerServiceDto dto);
        Task<bool> DeleteCustomerServiceAsync(int id);
    }
}
