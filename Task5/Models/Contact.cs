using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5
{
    public class Contact
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
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }     
    }
}