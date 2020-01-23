using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5
{
    public class Contact: Entity
    {
        [Column("I")]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name contains only letters")]
        public string FirstName { get; set; }

        [Column("O")]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Middle name contains only letters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name not specified")]
        [Column("F")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name contains only letters")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Invalid last name length")]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {MiddleName} {LastName}"; } }

        [MaxLength(255)]
        //[RegularExpression(@"\(\+\d{3}\)\d{2}-\d{3}-\d{2}=\d{2}$")]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }     
    }
}