using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("FormMaster", Schema = "cust")]
    public class FormMaster : EntityBase
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Slug { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Category { get; set; }

        [StringLength(100)]
        public string? Icon { get; set; } = "heroicons_outline:document-text";

        public bool AllowPdf { get; set; } = true;
        public bool AllowEmail { get; set; } = true;
        public bool AllowView { get; set; } = true;
        public bool AllowDownload { get; set; } = false;

        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 0;

        [StringLength(500)]
        public string? VisibleForClientTypes { get; set; }
    }
}
