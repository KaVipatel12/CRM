using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRM_Api.Models.Base
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class EntityBase : IEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UpdUserID")]
        [JsonIgnore]
        public int? UpdateUserId { get; set; }

        [Column("UpdDT", TypeName = "datetime")]
        [JsonIgnore]
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
