using BCrypt.Net;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                return null; // User already exists
            }

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PhoneNo = registerDto.PhoneNo,
                IsAdmin = registerDto.IsAdmin,
                IsChecker = registerDto.IsChecker,
                IsSuperAdmin = registerDto.IsSuperAdmin,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.ID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
                return null;

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return null;

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.ID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<UserProfileDto?> GetUserInfoAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return new UserProfileDto
            {
                Id = user.ID.ToString(),
                Name = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                Avatar = null, 
                Status = "online"
            };
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "ThisIsADefaultSecretKeyThatShouldBeChangedInProduction"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.IsAdmin == true ? "Admin" : "User")
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
