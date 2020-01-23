using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5
{
    public class Contact: Entity
    {
        [Column("I")]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Column("O")]
        [MaxLength(255)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name not specified")]
        [Column("F")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Invalid last name length")]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {MiddleName} {LastName}"; } }

        [MaxLength(255)]
        //[RegularExpression(@"\(\+\d{3}\)\d{2}-\d{3}-\d{2}=\d{2}$")]
        [Phone]
        public string Phone { get; set; }
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }     
    }
}