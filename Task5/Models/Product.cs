using System;
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Product: Entity
    {
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}