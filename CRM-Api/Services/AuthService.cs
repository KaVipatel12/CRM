using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CRM_Api.Services.Interfaces;

namespace CRM_Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IConfiguration configuration,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return true; // Don't reveal if user exists

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            // Encode token for URL safety
            var encodedToken = System.Web.HttpUtility.UrlEncode(token);
            var resetLink = $"{_configuration["DashboardUrl"]?.Replace("/admin/jobs", "")}/reset-password?token={encodedToken}&email={user.Email}";

            var body = $@"
                <div style='font-family: sans-serif; padding: 20px; color: #333;'>
                    <h2>Reset Your Password</h2>
                    <p>Hello {user.FirstName},</p>
                    <p>We received a request to reset your password for the SSP CRM. Click the button below to set a new password:</p>
                    <a href='{resetLink}' style='display: inline-block; padding: 10px 20px; background-color: #4F46E5; color: white; text-decoration: none; border-radius: 5px; margin: 20px 0;'>Reset Password</a>
                    <p>If you didn't request this, you can safely ignore this email.</p>
                    <p>This link will expire in 2 hours.</p>
                </div>";

            await _emailService.SendEmailAsync(user.Email!, "Reset Your Password - SSP CRM", body, "Password Reset");
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return false;

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            return result.Succeeded;
        }

        public async Task<RegistrationResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return new RegistrationResponseDto
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            // Assign standard Identity Roles
            if (registerDto.IsAdmin == true) await _userManager.AddToRoleAsync(user, "Admin");
            if (registerDto.IsChecker == true) await _userManager.AddToRoleAsync(user, "Checker");
            if (registerDto.IsSuperAdmin == true) await _userManager.AddToRoleAsync(user, "SuperAdmin");

            var token = await GenerateJwtToken(user);

            return new RegistrationResponseDto
            {
                Succeeded = true,
                Data = new AuthResponseDto
                {
                    Token = token,
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsAdmin = registerDto.IsAdmin,
                    IsChecker = registerDto.IsChecker,
                    IsSuperAdmin = registerDto.IsSuperAdmin
                }
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            var token = await GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAdmin = roles.Contains("Admin") || roles.Contains("SuperAdmin"),
                IsChecker = roles.Contains("Checker"),
                IsSuperAdmin = roles.Contains("SuperAdmin")
            };
        }

        public async Task<UserProfileDto?> GetUserInfoAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserProfileDto
            {
                Id = user.Id.ToString(),
                Name = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                Avatar = null,
                Status = "online",
                IsAdmin = roles.Contains("Admin") || roles.Contains("SuperAdmin"),
                IsChecker = roles.Contains("Checker"),
                IsSuperAdmin = roles.Contains("SuperAdmin")
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.Email ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Fallback role if none assigned
            if (!roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is missing");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
