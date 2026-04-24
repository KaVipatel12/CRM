using CRM_Api.Data;
using CRM_Api.Helpers;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CRM_Api.Services
{
    public class SmtpConfigurationService : ISmtpConfigurationService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IEncryptionService _encryptionService;
        private readonly ILogger<SmtpConfigurationService> _logger;
        private const string CacheKey = "ActiveSmtpConfig";

        public SmtpConfigurationService(AppDbContext context, IMemoryCache cache, IEncryptionService encryptionService, ILogger<SmtpConfigurationService> logger)
        {
            _context = context;
            _cache = cache;
            _encryptionService = encryptionService;
            _logger = logger;
        }

        public async Task<SmtpSetting?> GetActiveConfigurationAsync()
        {
            // Try to get from cache first
            if (_cache.TryGetValue(CacheKey, out SmtpSetting? cachedConfig))
            {
                return cachedConfig;
            }

            // Fetch from DB
            var config = await _context.SmtpSettings
                .Where(s => s.IsActive)
                .OrderByDescending(s => s.UpdateDateTime)
                .FirstOrDefaultAsync();

            if (config != null)
            {
                // Decrypt the password for use in code
                config.EncryptedPassword = _encryptionService.Decrypt(config.EncryptedPassword);
                
                // Store in cache for 1 hour
                _cache.Set(CacheKey, config, TimeSpan.FromHours(1));
            }
            else
            {
                _logger.LogWarning("No active SMTP configuration found in the database!");
            }

            return config;
        }

        public async Task<SmtpSetting> SaveConfigurationAsync(SmtpSetting setting)
        {
            // Encrypt the password before saving
            if (!string.IsNullOrEmpty(setting.EncryptedPassword))
            {
                setting.EncryptedPassword = _encryptionService.Encrypt(setting.EncryptedPassword);
            }

            if (setting.Id == 0)
            {
                _context.SmtpSettings.Add(setting);
            }
            else
            {
                _context.Entry(setting).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            
            // Invalidate cache since settings changed
            ClearCache();

            return setting;
        }

        public void ClearCache()
        {
            _cache.Remove(CacheKey);
        }
    }
}
