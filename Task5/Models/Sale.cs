
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Sale: Entity
    {
        [Required]
        public System.Guid ClientId { get; set; }
        [Required]
        public System.Guid ProductId { get; set; }
        [Required(ErrorMessage = "Не указана сумма")]
        public decimal Sum { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        public System.Guid CreatedByUserId { get; set; }
        [Required]
        public System.DateTime CreatedDateTime { get; set; }
    }
}