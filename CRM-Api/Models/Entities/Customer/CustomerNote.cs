using CRM_Api.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("CustomerNotes", Schema = "cust")]
    public class CustomerNote : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string NoteText { get; set; } = string.Empty;

        public bool IsPinned { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
    }
}
