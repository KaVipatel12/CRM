using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Operations
{
    [Table("Calllogs")]
    public class CallLogs : EntityBase, IApiResultModel
    {
        public DateTime ReceiveDate { get; set; }
        public int? Receiver { get; set; }
        public int? ForWhom { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [StringLength(20)]
        public string MobileNo { get; set; } = string.Empty;
        [StringLength(50)]
        public string CompanyName { get; set; } = string.Empty;
        public int? Purpose { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool? IsClosed { get; set; }
        public bool? IsChecked { get; set; }
        public string OtherPurpose { get; set; } = string.Empty;
        
        // Storing checkbox selections as comma-separated strings
        public string NatureOfBusiness { get; set; } = string.Empty; 
        public string OtherNatureOfBusiness { get; set; } = string.Empty;
        public string HearAboutUs { get; set; } = string.Empty;
        public string OtherHearAboutUs { get; set; } = string.Empty;

        [ForeignKey("Purpose")]
        public virtual Purpose? PurposeNavigation { get; set; }

        [ForeignKey("Status")]
        public virtual Customer.JobStatusMaster? StatusNavigation { get; set; }

        public virtual ICollection<CallLogComment> Comments { get; set; } = new List<CallLogComment>();
    }

    [Table("Purpose")]
    public class Purpose
    {
        public int ID { get; set; }
        public string PurposeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public virtual ICollection<CallLogs> CallLogsPurposeNavigation { get; set; } = new List<CallLogs>();
    }

    [Table("CallLogComments")]
    public class CallLogComment : EntityBase, IApiResultModel
    {
        public int CallLogId { get; set; }
        public string Comment { get; set; } = string.Empty;

        [ForeignKey("CallLogId")]
        public virtual CallLogs CallLog { get; set; } = null!;
    }

    [Table("Job", Schema = "task")]
    public class Job : EntityBase, IApiResultModel
    {
        public int? CustomerId { get; set; }
        
        [Required]
        public int JobTypeId { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Caption { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public int Priority { get; set; } // 0: Low, 1: Medium, 2: High, 3: Overdue
        
        public int? CurrentStage { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? Deadline { get; set; }
        
        public int? OwnerId { get; set; }
        
        public int? ResponsibleId { get; set; }
        
        public int? OriginalResponsibleId { get; set; }
        public DateTime? TemporaryAssignmentUntil { get; set; }
        public string? TemporaryAssignmentNote { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public bool IsRecurring { get; set; } = false;
        
        public bool IsInternal { get; set; } = false;

        public int? Period { get; set; }
        public string? RecurringMode { get; set; } // Weekly, Monthly, Quarterly, Yearly
        public int? ParentJobId { get; set; }
        public Job? ParentJob { get; set; }

        public DateTime? NextAutoCreateDate { get; set; }

        public DateTime? TargetEndDate { get; set; }
        public int? DueDateDays { get; set; }
        public string? DueDateBasis { get; set; }

        // CreatedDate was removed as it is now inherited from EntityBase as CreatedDateTime


        [ForeignKey("CustomerId")]
        public virtual Customer.Customer Customer { get; set; }

        [ForeignKey("JobTypeId")]
        public virtual Customer.TypeMaster JobType { get; set; }

        [ForeignKey("CurrentStage")]
        public virtual Customer.JobStatusMaster? Status { get; set; }

        public virtual ICollection<JobTask> Tasks { get; set; } = new List<JobTask>();
        public virtual ICollection<JobComment> Comments { get; set; } = new List<JobComment>();
        public virtual ICollection<JobHistory> History { get; set; } = new List<JobHistory>();
    }

    [Table("JobTask", Schema = "task")]
    public class JobTask : EntityBase, IApiResultModel
    {
        [Required]
        public int JobId { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public DateTime? CompletedDate { get; set; }
        
        public int Sequence { get; set; }

        // CreatedDate was removed as it is now inherited from EntityBase as CreatedDateTime


        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }

    [Table("JobComment", Schema = "task")]
    public class JobComment : EntityBase, IApiResultModel
    {
        [Required]
        public int JobId { get; set; }
        
        public int UserId { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        // CreatedAt was removed as it is now inherited from EntityBase as CreatedDateTime


        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }

    [Table("JobHistory", Schema = "task")]
    public class JobHistory : EntityBase, IApiResultModel
    {
        [Required]
        public int JobId { get; set; }
        
        [Required]
        public string Event { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}
