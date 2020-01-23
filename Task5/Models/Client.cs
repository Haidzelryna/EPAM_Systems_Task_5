
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Client: Entity
    {
        [Required(ErrorMessage = "Сontact not selected")]
        public System.Guid ContactId { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}