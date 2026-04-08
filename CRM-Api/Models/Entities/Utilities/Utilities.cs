using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Utilities
{
    [Table("Services", Schema = "cust")]
    public class Services : EntityBase, IApiResultModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<CustomerServices> CustomerServices { get; set; } = new List<CustomerServices>();
    }

    [Table("CustomerServices", Schema = "cust")]
    public class CustomerServices : EntityBase, IApiResultModel
    {
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public decimal? Amount { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        
        [ForeignKey("ServiceID")]
        public virtual Services Services { get; set; } = null!;
    }

    [Table("FileUploadInfo", Schema = "file")]
    public class FileUploadInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int FileType { get; set; }

        [Required]
        [StringLength(150)]
        public string FileOriginalName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string FileServerPath { get; set; } = string.Empty;

        public long? FileSize { get; set; }
        public long? RecordCount { get; set; }
        public long? RecordProcessed { get; set; }
        public long? RecordFailed { get; set; }
        public int UploadedBy { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public int? ProcessResult { get; set; }
        public string ProcessResultLogFile { get; set; } = string.Empty;
    }

    [Table("ActionConfiguration", Schema = "setting")]
    public class ActionConfiguration
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FromEmail { get; set; } = string.Empty;
        public int? SMTPPort { get; set; }
        public string SMTPHost { get; set; } = string.Empty;
        public string CCEmail1 { get; set; } = string.Empty;
        public string CCEmail2 { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    [Table("EmailTemplateMaster", Schema = "dbo")]
    public class EmailTemplateMaster
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

    [Table("ContactNotes", Schema = "cust")]
    public class ContactNote : IApiResultModel
    {
        public int? ID { get; set; }
        public string Note { get; set; } = string.Empty;
        public int? CategoryID { get; set; }
        [Column("UpdUserID")]
        public int? UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime UpdateDateTime { get; set; }
        public int? CustomerID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual NoteCategory NoteCategory { get; set; } = null!;
    }

    [Table("NoteCategory", Schema = "cust")]
    public class NoteCategory : IApiResultModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }

    [Table("NoteForFSMaster", Schema = "cust")]
    public class NoteForFSMaster : IApiResultModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }

    [Table("NoteForFS", Schema = "cust")]
    public class NoteForFS : IApiResultModel
    {
        public int? ID { get; set; }
        public string Note { get; set; } = string.Empty;
        public int? NoteTypeID { get; set; }
        public bool? IsChecked { get; set; }
        [Column("UpdUserID")]
        public int? UpdateUserId { get; set; }
        [Column("UpdDT", TypeName = "datetime")]
        public DateTime UpdateDateTime { get; set; }
        public int? CustomerID { get; set; }

        [ForeignKey("NoteTypeID")]
        public virtual NoteForFSMaster NoteForFSMaster { get; set; } = null!;
    }
}
