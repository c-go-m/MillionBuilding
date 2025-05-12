using Entities.Common;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Password { get; set; } = string.Empty;
    }
}
