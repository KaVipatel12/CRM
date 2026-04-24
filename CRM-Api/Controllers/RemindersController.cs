using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IAdminReminderService _adminReminderService;
        private readonly IConfiguration _configuration;

        public RemindersController(IAdminReminderService adminReminderService, IConfiguration configuration)
        {
            _adminReminderService = adminReminderService;
            _configuration = configuration;
        }

        [HttpPost("daily-admin")]
        public async Task<IActionResult> SendDailyAdminReminder([FromQuery] string? email)
        {
            // Use provided email or fallback to configuration
            string adminEmail = email ?? _configuration["AdminEmail"] ?? "admin@supersmartplans.com";
            
            bool result = await _adminReminderService.SendDailyAdminReminderAsync(adminEmail);
            
            if (result)
                return Ok(new { message = $"Daily Admin Reminder sent successfully to {adminEmail}" });
            
            return StatusCode(500, new { message = "Failed to send Admin Reminder. Check SMTP logs." });
        }

        [HttpPost("overdue-jobs")]
        public async Task<IActionResult> SendOverdueJobs([FromQuery] string? email)
        {
            // Use provided email or fallback to first admin
            string adminEmail = email ?? "admin@supersmartplans.com";
            
            bool result = await _adminReminderService.SendOverdueJobReminderAsync(adminEmail);
            
            if (result)
                return Ok(new { message = $"Overdue Job Report sent successfully to {adminEmail}" });
            
            return StatusCode(500, new { message = "Failed to send Overdue Job Report. Check SMTP logs." });
        }
    }
}
