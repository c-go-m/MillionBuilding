using System.ComponentModel.DataAnnotations;

namespace Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
