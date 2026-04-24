using System;

namespace CRM_Api.DTOs
{
    public class CustomerRelationshipDto
    {
        public int Id { get; set; }
        public int SourceCustomerId { get; set; }
        public int TargetCustomerId { get; set; }
        public int RelationshipTypeId { get; set; }
        public string RelationshipTypeName { get; set; } = string.Empty;
        public string TargetCustomerName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? NoOfShare { get; set; }
        public string? Note { get; set; }
    }

    public class CreateCustomerRelationshipDto
    {
        public int SourceCustomerId { get; set; }
        public int TargetCustomerId { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? NoOfShare { get; set; }
        public string? Note { get; set; }
    }

    public class LookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
