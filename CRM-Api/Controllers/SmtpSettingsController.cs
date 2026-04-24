using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SmtpSettingsController : ControllerBase
    {
        private readonly ISmtpConfigurationService _smtpService;

        public SmtpSettingsController(ISmtpConfigurationService smtpService)
        {
            _smtpService = smtpService;
        }

        [HttpGet]
        public async Task<ActionResult<SmtpSetting>> Get()
        {
            var settings = await _smtpService.GetActiveConfigurationAsync();
            if (settings == null)
            {
                return Ok(new SmtpSetting { IsActive = true });
            }
            
            // Create a copy so we don't pollute the cache
            var uiSettings = new SmtpSetting
            {
                Id = settings.Id,
                ProviderName = settings.ProviderName,
                Host = settings.Host,
                Port = settings.Port,
                Username = settings.Username,
                FromEmail = settings.FromEmail,
                FromName = settings.FromName,
                CCEmailsJson = settings.CCEmailsJson,
                IsActive = settings.IsActive,
                // Do NOT send the real password to the UI
                EncryptedPassword = !string.IsNullOrEmpty(settings.EncryptedPassword) ? "****************" : ""
            };

            return Ok(uiSettings);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<ActionResult<SmtpSetting>> Save([FromBody] SmtpSetting settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // If the user didn't change the password (it's still our placeholder), 
            // we should not overwrite it with the placeholder stars.
            if (settings.EncryptedPassword == "****************")
            {
                var existing = await _smtpService.GetActiveConfigurationAsync();
                if (existing != null)
                {
                    settings.EncryptedPassword = existing.EncryptedPassword;
                }
            }

            var savedSettings = await _smtpService.SaveConfigurationAsync(settings);
            return Ok(savedSettings);
        }
    }
}
