using Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{

    public class Owner : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? Photo { get; set; }

        public DateTime? Birthday { get; set; }

        [JsonIgnore]
        public virtual ICollection<Property>? Properties { get; set; }
    }
}