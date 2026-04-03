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
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string MobileNo { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        public int? Purpose { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsChecked { get; set; }
        public string OtherPurpose { get; set; }
        public string NatureOfBusiness { get; set; }
        public string OtherNatureOfBusiness { get; set; }
        public string HearAboutUs { get; set; }
        public string OtherHearAboutUs { get; set; }

        [ForeignKey("Purpose")]
        public virtual Purpose PurposeNavigation { get; set; }
    }

    [Table("Purpose")]
    public class Purpose
    {
        public int ID { get; set; }
        public string PurposeName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<CallLogs> CallLogsPurposeNavigation { get; set; }
    }

    [Table("Action", Schema = "task")]
    public class TaskAction
    {
        public int ID { get; set; }
        public int? ScheduleID { get; set; }
        public int? DetailID { get; set; }
        public int? ActionMasterID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Column("ExecutionStartDate", TypeName = "date")]
        public DateTime? ExecutionStartDate { get; set; }
        public string ExecutionStartTime { get; set; }
        [Column("ExecutionEndDate", TypeName = "date")]
        public DateTime? ExecutionEndDate { get; set; }
        public string ExecutionEndTime { get; set; }
        public bool? IsBackground { get; set; }
        public bool? Status { get; set; }
        public string PerformAction { get; set; }
        public int? TaskOwner { get; set; }
        public int? AssignTo { get; set; }
        public string EmailJson { get; set; }
        public bool IsRunning { get; set; }
        public int NoOfTry { get; set; }
        public string GroupName { get; set; }
        public int? Stage { get; set; }
        public int? DueDuration { get; set; }
        public string DueMode { get; set; }
        [Column("DueDate", TypeName = "date")]
        public DateTime? DueDate { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? ClosedDateTime { get; set; }
        public int? Priority { get; set; }
        [Column("UpdUserID")]
        public int? UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? AssignDateTime { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("DetailID")]
        public virtual Detail Detail { get; set; }
        [ForeignKey("ScheduleID")]
        public virtual Schedule Schedule { get; set; }
    }

    [Table("Detail", Schema = "task")]
    public class Detail : IApiResultModel
    {
        public int ID { get; set; }
        public int? ScheduleID { get; set; }
        public int? ClientId { get; set; }
        public int TypeID { get; set; }
        public DateTime? PeriodEnded { get; set; }
        public string Caption { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? TaskOwner { get; set; }
        public int? Priority { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserID { get; set; }
        public int? AssignTo { get; set; }
        public int? AssignBy { get; set; }
        public bool? IsRecurring { get; set; }
        public string PerformAction { get; set; }
        public int? Stage { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<TaskAction> Action { get; set; }

        [ForeignKey("TypeID")]
        public virtual CRM_Api.Models.Entities.Customer.TypeMaster Type { get; set; }
    }

    [Table("Schedule", Schema = "task")]
    public class Schedule : EntityBase
    {
        public string Mode { get; set; }
        public string Caption { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
        public string ScheduleDays { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? DueDuration { get; set; }
        public string DueMode { get; set; }

        public virtual ICollection<TaskAction> Action { get; set; }
        public virtual ICollection<Detail> Detail { get; set; }
    }

    [Table("JobTodoList", Schema = "task")]
    public class JobTodo : IApiResultModel
    {
        public int? ID { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        [Column("UpdUserID")]
        public int UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime UpdateDateTime { get; set; }
        public int JobDetailID { get; set; }

        [ForeignKey("JobDetailID")]
        public virtual Detail Detail { get; set; }
    }

    [Table("ActionHistory", Schema = "task")]
    public class TaskActionHistory
    {
        public int ID { get; set; }
        public int ActionID { get; set; }
        public int? ScheduleID { get; set; }
        public int? DetailID { get; set; }
        public int? ActionMasterID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Column("ExecutionStartDate", TypeName = "date")]
        public DateTime? ExecutionStartDate { get; set; }
        public string ExecutionStartTime { get; set; }
        [Column("ExecutionEndDate", TypeName = "date")]
        public DateTime? ExecutionEndDate { get; set; }
        public string ExecutionEndTime { get; set; }
        public bool? IsBackground { get; set; }
        public bool? Status { get; set; }
        public string PerformAction { get; set; }
        public int? TaskOwner { get; set; }
        public int? AssignTo { get; set; }
        public string EmailJson { get; set; }
        public bool IsRunning { get; set; }
        public int NoOfTry { get; set; }
        public string GroupName { get; set; }
        public int? Stage { get; set; }
        public int? DueDuration { get; set; }
        public string DueMode { get; set; }
        [Column("DueDate", TypeName = "date")]
        public DateTime? DueDate { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? ClosedDateTime { get; set; }
        [Column("UpdUserID")]
        public int? UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? AssignDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? Priority { get; set; }

        [ForeignKey("ActionID")]
        public virtual TaskAction Action { get; set; }
    }

    [Table("Comments", Schema = "task")]
    public class TaskComment : IApiResultModel
    {
        public int? ID { get; set; }
        public string Comment { get; set; }
        [Column("UpdUserID")]
        public int UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime UpdateDateTime { get; set; }
        public int TaskActionID { get; set; }

        [ForeignKey("TaskActionID")]
        public virtual TaskAction Action { get; set; }
    }
}
