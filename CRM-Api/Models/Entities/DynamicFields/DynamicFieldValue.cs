using CRM_Api.Models.Base;
using CRM_Api.Models.Entities.Customer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.DynamicFields
{
    [Table("DynamicFieldValues", Schema = "dbo")]
    public class DynamicFieldValue : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int FieldId { get; set; }

        public string? FieldValue { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CRM_Api.Models.Entities.Customer.Customer? Customer { get; set; }

        [ForeignKey("FieldId")]
        public virtual DynamicFieldMaster? FieldMaster { get; set; }
    }
}
