using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models
{
    [Table("Users", Schema = "dbo")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public bool? IsAdmin { get; set; }
        public string? PasswordHash { get; set; }
        public bool? IsChecker { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }
}
