using CRM_Api.DTOs;
using CRM_Api.Models;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto);
        Task<UserProfileDto?> GetUserInfoAsync(int userId);
    }
}
