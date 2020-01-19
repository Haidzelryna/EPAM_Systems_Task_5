//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact: Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            this.Client = new HashSet<Client>();
            this.Manager = new HashSet<Manager>();
        }
    
        public System.Guid Id { get; set; }

        [Column("I")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Column("O")]
        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Column("F")]
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Client> Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Manager> Manager { get; set; }
    }
}
