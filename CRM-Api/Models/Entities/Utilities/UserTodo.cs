using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Utilities
{
    [Table("UserTodos")]
    public class UserTodo : EntityBase
    {
        [Required]
        [Column("UserID")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Note { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
