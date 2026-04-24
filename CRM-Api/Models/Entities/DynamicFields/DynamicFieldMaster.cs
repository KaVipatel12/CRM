using CRM_Api.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.DynamicFields
{
    [Table("DynamicFieldMasters", Schema = "dbo")]
    public class DynamicFieldMaster : EntityBase, IApiResultModel
    {
        [Required]
        [StringLength(100)]
        public string FieldName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string DisplayName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FieldType { get; set; } = "string"; // boolean, dropdown, string, textarea

        [StringLength(100)]
        public string? FieldAbbreviation { get; set; }

        public string? DefaultValue { get; set; }

        [StringLength(100)]
        public string? Category { get; set; } = "General";

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public int SortOrder { get; set; } = 0;

        public string? Options { get; set; }
        
        public string? DisplayTypeIds { get; set; } // Comma separated IDs of customer types
    }
}
