using CRM_Api.Data;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class PasswordManagerService : IPasswordManagerService
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;
        private readonly ILogger<PasswordManagerService> _logger;

        public PasswordManagerService(AppDbContext context, IEncryptionService encryptionService, ILogger<PasswordManagerService> logger)
        {
            _context = context;
            _encryptionService = encryptionService;
            _logger = logger;
        }

        public async Task<IEnumerable<PasswordManager>> GetPasswordsAsync()
        {
            var passwords = await _context.PasswordManagers
                .OrderBy(p => p.Title)
                .ToListAsync();

            // Clear passwords for the list view
            foreach (var p in passwords)
            {
                p.Password = null;
            }

            return passwords;
        }

        public async Task<PasswordManager?> GetPasswordByIdAsync(int id)
        {
            var password = await _context.PasswordManagers.FindAsync(id);
            if (password != null && !string.IsNullOrEmpty(password.Password))
            {
                password.Password = _encryptionService.Decrypt(password.Password);
            }
            return password;
        }

        public async Task<PasswordManager> SavePasswordAsync(PasswordManager passwordManager)
        {
            if (!string.IsNullOrEmpty(passwordManager.Password))
            {
                passwordManager.Password = _encryptionService.Encrypt(passwordManager.Password);
            }

            if (passwordManager.Id == 0)
            {
                _context.PasswordManagers.Add(passwordManager);
            }
            else
            {
                _context.Entry(passwordManager).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return passwordManager;
        }

        public async Task<bool> DeletePasswordAsync(int id)
        {
            var password = await _context.PasswordManagers.FindAsync(id);
            if (password == null) return false;

            _context.PasswordManagers.Remove(password);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerifyMasterPasswordAsync(string password)
        {
            var config = await _context.VaultConfigurations.FirstOrDefaultAsync();
            if (config == null || string.IsNullOrEmpty(config.MasterPassword))
            {
                return false;
            }

            string decryptedMaster = _encryptionService.Decrypt(config.MasterPassword);
            return decryptedMaster == password;
        }

        public async Task<bool> SetMasterPasswordAsync(string password)
        {
            _logger.LogInformation("Setting master password. Length of input: {Length}", password?.Length ?? 0);
            
            var config = await _context.VaultConfigurations.FirstOrDefaultAsync();
            
            string encryptedMaster = _encryptionService.Encrypt(password);
            _logger.LogInformation("Encrypted master password length: {Length}", encryptedMaster?.Length ?? 0);

            if (config == null)
            {
                _logger.LogInformation("Creating new VaultConfiguration");
                config = new VaultConfiguration { MasterPassword = encryptedMaster };
                _context.VaultConfigurations.Add(config);
            }
            else
            {
                _logger.LogInformation("Updating existing VaultConfiguration ID: {Id}", config.Id);
                config.MasterPassword = encryptedMaster;
                _context.Entry(config).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsMasterPasswordSetAsync()
        {
            var config = await _context.VaultConfigurations.FirstOrDefaultAsync();
            return config != null && !string.IsNullOrEmpty(config.MasterPassword);
        }
    }
}
