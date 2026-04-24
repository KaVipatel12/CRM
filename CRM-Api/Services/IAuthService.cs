using CRM_Api.DTOs;
using CRM_Api.Models;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<RegistrationResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<UserProfileDto?> GetUserInfoAsync(int userId);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
