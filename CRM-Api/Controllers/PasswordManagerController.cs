using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordManagerController : ControllerBase
    {
        private readonly IPasswordManagerService _passwordManagerService;

        public PasswordManagerController(IPasswordManagerService passwordManagerService)
        {
            _passwordManagerService = passwordManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPasswords()
        {
            var passwords = await _passwordManagerService.GetPasswordsAsync();
            return Ok(passwords);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPassword(int id)
        {
            if (!await VerifyHeader()) return BadRequest(new { message = "Invalid or missing Master Password" });

            var password = await _passwordManagerService.GetPasswordByIdAsync(id);
            if (password == null) return NotFound();
            return Ok(password);
        }

        [HttpPost]
        public async Task<IActionResult> SavePassword([FromBody] SavePasswordRequest request)
        {
            if (!await _passwordManagerService.VerifyMasterPasswordAsync(request.MasterPassword))
            {
                return BadRequest(new { message = "Invalid Master Password" });
            }

            var saved = await _passwordManagerService.SavePasswordAsync(request.PasswordData);
            return Ok(saved);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            if (!await VerifyHeader()) return BadRequest(new { message = "Invalid or missing Master Password" });

            var deleted = await _passwordManagerService.DeletePasswordAsync(id);
            if (!deleted) return NotFound();
            return Ok(new { message = "Password deleted successfully" });
        }

        private async Task<bool> VerifyHeader()
        {
            if (!Request.Headers.TryGetValue("X-Vault-Master-Password", out var masterPassword))
            {
                return false;
            }
            return await _passwordManagerService.VerifyMasterPasswordAsync(masterPassword!);
        }

        [HttpGet("master-password-status")]
        public async Task<IActionResult> GetMasterPasswordStatus()
        {
            var isSet = await _passwordManagerService.IsMasterPasswordSetAsync();
            return Ok(new { isSet });
        }

        [HttpPost("verify-master-password")]
        public async Task<IActionResult> VerifyMasterPassword([FromBody] MasterPasswordRequest request)
        {
            var isValid = await _passwordManagerService.VerifyMasterPasswordAsync(request.MasterPassword);
            return Ok(new { isValid });
        }

        [HttpPost("set-master-password")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> SetMasterPassword([FromBody] MasterPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.MasterPassword))
            {
                return BadRequest(new { message = "Password cannot be empty" });
            }

            var success = await _passwordManagerService.SetMasterPasswordAsync(request.MasterPassword);
            return Ok(new { success });
        }
    }

    public class MasterPasswordRequest
    {
        public string MasterPassword { get; set; } = string.Empty;
    }

    public class SavePasswordRequest
    {
        public PasswordManager PasswordData { get; set; } = null!;
        public string MasterPassword { get; set; } = string.Empty;
    }
}
