using System;

namespace CRM_Api.DTOs
{
    public class ChecklistItemDto
    {
        // Info from Master Table
        public int ChecklistMasterId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public int SortOrder { get; set; }

        // Info from Status Table (Customer Specific)
        public int? StatusId { get; set; } // Null means not interacted with yet
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDT { get; set; }
        public int? CompletedByUserID { get; set; }
        public string? CompletedByUserName { get; set; }
        public string? Notes { get; set; }
    }

    public class ToggleChecklistDto
    {
        public int CustomerId { get; set; }
        public int ChecklistMasterId { get; set; }
        public bool IsCompleted { get; set; }
        public string? Notes { get; set; }
    }
}
