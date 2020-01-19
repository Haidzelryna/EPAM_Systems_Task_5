
using System;

namespace BLL.Model.BaseEntity
{
    public class BaseEntity : Entity
    {
        public Guid? CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
