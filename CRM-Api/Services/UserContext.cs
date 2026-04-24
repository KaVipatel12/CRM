using System.Security.Claims;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CRM_Api.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                var userIdStr = user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? user?.FindFirstValue("id");
                
                if (int.TryParse(userIdStr, out int userId))
                {
                    return userId;
                }

                return null;
            }
        }

        public bool IsAdmin => _httpContextAccessor.HttpContext?.User?.IsInRole("Admin") ?? false;
        public bool IsSuperAdmin => _httpContextAccessor.HttpContext?.User?.IsInRole("SuperAdmin") ?? false;
    }
}
