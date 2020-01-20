
using System;
using Task5.Model.BaseEntity;

namespace Task5
{
    public class Manager : Entity
    {
        public string Name { get; set; }

        public Guid ContactId { get; set; }
    }
}
