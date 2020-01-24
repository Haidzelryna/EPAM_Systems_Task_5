using System;
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Product: Entity
    {
        [Required(ErrorMessage = "Price not specified")]
        //[RegularExpression(@"^\d+(?:[\.,]\d+)?$", 
        //ErrorMessage = "Price must contain only numbers, dot or comma")]
        public Nullable<decimal> Price { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}