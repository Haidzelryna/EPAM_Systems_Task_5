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
        [Required]
        [Column("F")]
        [MaxLength(255)]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {MiddleName} {LastName}"; } }

    [MaxLength(50)]
        //[RegularExpression(@"\(\+\d{3}\)\d{2}-\d{3}-\d{2}=\d{2}$")]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }     
    }
}