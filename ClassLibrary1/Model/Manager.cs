
using System;
using BLL.Model.BaseEntity;

namespace BLL
{
    public class Manager : Entity
    {
        public string Name { get; set; }

        public Guid ContactId { get; set; }
    }
}
