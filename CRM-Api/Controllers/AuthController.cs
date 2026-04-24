using CRM_Api.DTOs;
using CRM_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

using CRM_Api.Services.Interfaces;

namespace CRM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserContext _userContext;

        public AuthController(IAuthService authService, IUserContext userContext)
        {
            _authService = authService;
            _userContext = userContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.RegisterAsync(registerDto);

            if (!response.Succeeded)
            {
                return BadRequest(new { errors = response.Errors });
            }

            return Ok(response.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.LoginAsync(loginDto);

            if (response == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            await _authService.ForgotPasswordAsync(dto);
            return Ok(new { message = "If your email is registered, you will receive a reset link shortly." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var result = await _authService.ResetPasswordAsync(dto);
            if (!result) return BadRequest(new { message = "Invalid token or request." });
            return Ok(new { message = "Password has been reset successfully." });
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Auth API is reachable");
        }

        [Authorize]
        [HttpGet("user")]
        [HttpGet("/api/common/user")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = _userContext.UserId;
            if (userId == null) return Unauthorized();

            var userProfile = await _authService.GetUserInfoAsync(userId.Value);
            if (userProfile == null) return NotFound();

            return Ok(userProfile);
        }
    }
}
