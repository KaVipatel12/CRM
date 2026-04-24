using System;

namespace CRM_Api.DTOs
{
    public class UserTodoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public CRM_Api.Models.Entities.Utilities.TodoPriority Priority { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }

    public class CreateUserTodoDto
    {
        public string Note { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public CRM_Api.Models.Entities.Utilities.TodoPriority Priority { get; set; } = CRM_Api.Models.Entities.Utilities.TodoPriority.Medium;
    }

    public class UpdateUserTodoDto
    {
        public int Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public CRM_Api.Models.Entities.Utilities.TodoPriority Priority { get; set; }
    }
}
