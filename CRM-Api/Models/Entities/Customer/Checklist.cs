using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("ChecklistMaster", Schema = "dbo")]
    public class ChecklistMaster : EntityBase, IApiResultModel
    {
        [Required]
        [StringLength(200)]
        public string TaskName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = "General"; // Onboarding, Compliance, etc.

        [StringLength(100)]
        public string? ApplicableClientType { get; set; } // e.g., "Company,Trust" or "All"

        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }

    [Table("CustomerChecklistStatus", Schema = "cust")]
    public class CustomerChecklistStatus : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int ChecklistMasterID { get; set; }

        public bool IsCompleted { get; set; } = false;

        [Column(TypeName = "datetime")]
        public DateTime? CompletedDT { get; set; }

        public int? CompletedByUserID { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey("ChecklistMasterID")]
        public virtual ChecklistMaster ChecklistMaster { get; set; } = null!;
        
        [ForeignKey("CompletedByUserID")]
        public virtual CRM_Api.Models.User? CompletedByUser { get; set; }
    }
}
