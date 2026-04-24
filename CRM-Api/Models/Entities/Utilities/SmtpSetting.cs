using CRM_Api.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.Utilities
{
    [Table("SmtpSettings", Schema = "setting")]
    public class SmtpSetting : EntityBase
    {
        public string ProviderName { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
        public string Username { get; set; } = string.Empty;
        public string EncryptedPassword { get; set; } = string.Empty;
        public string FromEmail { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
        
        public string? CCEmailsJson { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
