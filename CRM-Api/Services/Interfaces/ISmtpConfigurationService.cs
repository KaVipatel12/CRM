using CRM_Api.Models.Entities.Utilities;

namespace CRM_Api.Services.Interfaces
{
    public interface ISmtpConfigurationService
    {
        /// <summary>
        /// Gets the active SMTP configuration from the database with the password decrypted.
        /// Results are cached for performance.
        /// </summary>
        Task<SmtpSetting?> GetActiveConfigurationAsync();

        /// <summary>
        /// Saves or updates the SMTP configuration, automatically encrypting the password.
        /// </summary>
        Task<SmtpSetting> SaveConfigurationAsync(SmtpSetting setting);
        
        /// <summary>
        /// Clears the configuration cache.
        /// </summary>
        void ClearCache();
    }
}
