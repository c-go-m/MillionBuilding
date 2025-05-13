using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PropertyImage : BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public string? File { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        [ForeignKey("Property")]
        public int IdProperty { get; set; }

        [JsonIgnore]
        public virtual Property? Property { get; set; }
    }
}
