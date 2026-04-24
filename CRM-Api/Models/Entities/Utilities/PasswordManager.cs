using CRM_Api.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.Utilities
{
    [Table("PasswordManager", Schema = "setting")]
    public class PasswordManager : EntityBase
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string? URL { get; set; }
        
        public string? UserName { get; set; }
        
        public string? Password { get; set; }
        
        public string? Note { get; set; }
    }
}
