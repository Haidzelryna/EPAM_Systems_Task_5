
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Manager: Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public System.Guid ContactId { get; set; }
    }
}