
using System;

namespace Task5
{
    public class BaseEntity : Entity
    {
        public Guid? CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
