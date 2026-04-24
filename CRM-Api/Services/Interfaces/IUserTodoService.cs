using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface IUserTodoService
    {
        Task<IEnumerable<UserTodoDto>> GetByUserIdAsync(int userId);
        Task<UserTodoDto> AddAsync(int userId, CreateUserTodoDto dto);
        Task<bool> UpdateAsync(int userId, UpdateUserTodoDto dto);
        Task<bool> DeleteAsync(int userId, int id);
    }
}
