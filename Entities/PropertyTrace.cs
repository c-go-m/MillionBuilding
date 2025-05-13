using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class PropertyTrace : BaseEntity
    {
        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Required]
        [ForeignKey("Property")]
        public int IdProperty { get; set; }

        [JsonIgnore]
        public virtual Property? Property { get; set; }
    }
}
