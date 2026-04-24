namespace CRM_Api.DTOs
{
    public class RegisterDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsChecker { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegistrationResponseDto
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public AuthResponseDto? Data { get; set; }
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsChecker { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }

    public class UserProfileDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Status { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsChecker { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }
}
