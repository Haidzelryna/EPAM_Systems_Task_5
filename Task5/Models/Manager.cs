﻿
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class Manager: Entity
    {
        [Required(ErrorMessage = "Name not specified")]
        [MaxLength(255)]
        //[RegularExpression(@"/[A-Za-z\s]+", ErrorMessage = "First name contains only letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Сontact not selected")]
        public System.Guid ContactId { get; set; }

        public string UserId { get; set; }
    }
}