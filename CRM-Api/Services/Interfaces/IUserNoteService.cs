using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface IUserNoteService
    {
        Task<IEnumerable<UserNoteDto>> GetByUserIdAsync(int userId);
        Task<UserNoteDto> AddAsync(int userId, CreateUserNoteDto dto);
        Task<bool> UpdateAsync(int userId, UpdateUserNoteDto updateDto);
        Task<bool> DeleteAsync(int userId, int id);
        Task<int?> ConvertToTodoAsync(int userId, int id);
        Task<bool> UpdateOrderAsync(int userId, IEnumerable<UpdateNoteOrderDto> updates);
    }
}
