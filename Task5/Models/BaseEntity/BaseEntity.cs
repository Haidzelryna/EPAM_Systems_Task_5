using System;
using System.ComponentModel.DataAnnotations;

namespace Task5
{
    public class BaseEntity : Entity
    {
        [Required(ErrorMessage = "Manager not selected")]
        public Guid? CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
