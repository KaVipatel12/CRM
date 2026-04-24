using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("ContactType", Schema = "cust")]
    public class ContactType
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    [Table("CustomerType", Schema = "cust")]
    public class CustomerType : EntityBase, IApiResultModel
    {
        public string? CustomerTypeNM { get; set; }
        public int? EntityTypeID { get; set; }
    }

    [Table("EntityType", Schema = "cust")]
    public class EntityType : EntityBase, IApiResultModel
    {
        public string? EntityTypeNM { get; set; }
    }

    [Table("RelationShipType", Schema = "cust")]
    public class RelationShipType
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    [Table("JobStatusMaster", Schema = "task")]
    public class JobStatusMaster
    {
        public int ID { get; set; }
        public string? StatusName { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? ShowPriority { get; set; }
        public string? Color { get; set; }
        public string? Icon { get; set; }
    }

    [Table("TypeMaster", Schema = "task")]
    public class TypeMaster
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? ShortCode { get; set; }
        public string? Description { get; set; }
    }

    [Table("JobTypeStatusMapping", Schema = "task")]
    public class JobTypeStatusMapping
    {
        public int ID { get; set; }
        public int JobTypeId { get; set; }
        public int JobStatusMasterId { get; set; }
        public int? DisplayOrder { get; set; }

        [ForeignKey("JobTypeId")]
        public virtual TypeMaster? JobType { get; set; }
        
        [ForeignKey("JobStatusMasterId")]
        public virtual JobStatusMaster? JobStatusMaster { get; set; }
    }

    [Table("BusinessType", Schema = "cust")]
    public class BusinessType
    {
        public int Id { get; set; }
        public string? BusinessTypeNM { get; set; }
    }

    [Table("TaxAgent", Schema = "cust")]
    public class TaxAgent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    [Table("TradingStatus", Schema = "cust")]
    public class TradingStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    [Table("ServiceMaster", Schema = "cust")]
    public class ServiceMaster : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
