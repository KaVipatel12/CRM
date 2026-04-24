using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface ICustomerRelationshipService
    {
        Task<List<CustomerRelationshipDto>> GetByCustomerIdAsync(int customerId);
        Task<CustomerRelationshipDto> AddAsync(CreateCustomerRelationshipDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<LookupDto>> GetRelationshipTypesAsync();
    }
}
