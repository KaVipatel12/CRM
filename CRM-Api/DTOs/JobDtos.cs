using System;
using System.Collections.Generic;

namespace CRM_Api.DTOs
{
    public class JobDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? CustomerCode { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public bool IsInternal { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Priority { get; set; }
        public int? CurrentStage { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? StatusColor { get; set; }
        public string? StatusIcon { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? DaysLeft { get; set; }
        public int? OwnerId { get; set; }
        public int? ResponsibleId { get; set; }
        public int? OriginalResponsibleId { get; set; }
        public DateTime? TemporaryAssignmentUntil { get; set; }
        public int? Period { get; set; }
        public string? RecurringMode { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public int? DueDateDays { get; set; }
        public string? DueDateBasis { get; set; }
        public bool IsActive { get; set; }
        public bool IsRecurring { get; set; }
        public int? CreatedUserId { get; set; }
        public string? CreatedUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public List<JobTaskDto> Tasks { get; set; } = new();
        public List<JobCommentDto> Comments { get; set; } = new();
        public List<JobHistoryDto> History { get; set; } = new();
    }

    public class JobCreateUpdateDto
    {
        public int? CustomerId { get; set; }
        public bool IsInternal { get; set; }
        public int JobTypeId { get; set; }
        public string Caption { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Priority { get; set; }
        public int? CurrentStage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? OwnerId { get; set; }
        public int? ResponsibleId { get; set; }
        public int? Period { get; set; }
        public string? RecurringMode { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public int? DueDateDays { get; set; }
        public string? DueDateBasis { get; set; }
        public bool IsRecurring { get; set; }
        public List<JobTaskDto>? Tasks { get; set; }
    }

    public class JobTaskDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int Sequence { get; set; }
    }

    public class JobCommentDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
    }

    public class JobHistoryDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Event { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }

    public class JobFilterDto
    {
        public string? SearchString { get; set; }
        public int? StatusId { get; set; }
        public int? Priority { get; set; }
        public int? JobTypeId { get; set; }
        public int? OwnerId { get; set; }
        public int? ResponsibleId { get; set; }
        public int? CreatedUserId { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRecurring { get; set; }
        public bool? IsInternal { get; set; }
        public DateTime? DeadlineFrom { get; set; }
        public DateTime? DeadlineTo { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public string? OrderDirection { get; set; }
    }

    public class JobPagedResponseDto
    {
        public List<JobDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class ChartDataPoint
    {
        public string Label { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class JobStatisticsDto
    {
        public int TotalActive { get; set; }
        public int Active { get; set; }
        public int OnHold { get; set; }
        public int Overdue { get; set; }
        public int CreatedByMe { get; set; }
        public int OwnedByMe { get; set; }
        public int HighPriority { get; set; }
        public int TemporaryTasks { get; set; }
        public int TodoLater { get; set; }
        public int Completed { get; set; }
        public List<ChartDataPoint> JobsByStage { get; set; } = new();
        public List<ChartDataPoint> JobsByType { get; set; } = new();
    }

    public class BulkJobStatusUpdateDto
    {
        public List<int> JobIds { get; set; } = new();
        public int StatusId { get; set; }
    }

    public class BulkTemporaryAssignmentDto
    {
        public List<int> JobIds { get; set; } = new();
        public int StaffId { get; set; }
        public DateTime UntilDate { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
