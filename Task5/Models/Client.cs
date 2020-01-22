
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Client: Entity
    {
        [Required]
        public System.Guid ContactId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}