using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("FSNoteMaster", Schema = "dbo")]
    public class FSNoteMaster : EntityBase, IApiResultModel
    {
        [Required]
        [StringLength(200)]
        public string NoteType { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 0;
    }

    [Table("CustomerFSNote", Schema = "cust")]
    public class CustomerFSNote : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int FSNoteMasterID { get; set; }

        [Required]
        public string NoteContent { get; set; } = string.Empty;

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey("FSNoteMasterID")]
        public virtual FSNoteMaster FSNoteMaster { get; set; } = null!;

        [ForeignKey("UpdateUserId")]
        public virtual CRM_Api.Models.User? UpdatedByUser { get; set; }

        [ForeignKey("CreatedUserId")]
        public virtual CRM_Api.Models.User? CreatedByUser { get; set; }
    }
}
