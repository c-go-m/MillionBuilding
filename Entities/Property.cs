using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Property : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodeInternal { get; set; }

        public int Year { get; set; }

        [Required]
        [ForeignKey("Owner")]
        public int IdOwner { get; set; }

        [JsonIgnore]
        public virtual Owner? Owner { get; set; }

        [JsonIgnore]
        public virtual ICollection<PropertyImage>? PropertyImages { get; set; }

        [JsonIgnore]
        public virtual ICollection<PropertyTrace>? PropertyTraces { get; set; }
    }
}
