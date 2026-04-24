using CRM_Api.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("CustomerRelationships", Schema = "cust")]
    public class CustomerRelationship : EntityBase, IApiResultModel
    {
        [Required]
        public int SourceCustomerId { get; set; }

        [Required]
        public int TargetCustomerId { get; set; }

        [Required]
        public int RelationshipTypeId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? NoOfShare { get; set; }

        public string? Note { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("SourceCustomerId")]
        public virtual Customer? SourceCustomer { get; set; }

        [ForeignKey("TargetCustomerId")]
        public virtual Customer? TargetCustomer { get; set; }

        [ForeignKey("RelationshipTypeId")]
        public virtual RelationShipType? RelationshipType { get; set; }
    }
}
