using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Utilities
{
    public enum TodoPriority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

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

        public DateTime? DueDate { get; set; }
        
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
