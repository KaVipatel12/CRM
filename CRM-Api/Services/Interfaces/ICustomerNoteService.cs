using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface ICustomerNoteService
    {
        Task<IEnumerable<CustomerNoteDto>> GetByCustomerIdAsync(int customerId);
        Task<CustomerNoteDto> AddAsync(CreateCustomerNoteDto dto);
        Task<bool> UpdateAsync(UpdateCustomerNoteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
