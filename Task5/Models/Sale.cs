
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Sale: BaseEntity
    {
        [Required(ErrorMessage = "Сlient not selected")]
        public System.Guid ClientId { get; set; }

        [Required(ErrorMessage = "Product not selected")]
        public System.Guid ProductId { get; set; }

        [Required(ErrorMessage = "Amount not specified")]
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Date not specified")]
        public System.DateTime Date { get; set; }
    }
}