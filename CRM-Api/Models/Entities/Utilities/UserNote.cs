using CRM_Api.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.Utilities
{
    [Table("UserNotes", Schema = "user")]
    public class UserNote : EntityBase
    {
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
        public int DisplayOrder { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}
