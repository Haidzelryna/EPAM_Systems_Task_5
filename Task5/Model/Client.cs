
using System;
using BLL.Model.BaseEntity;

namespace BLL
{
    public class Client : Entity
    {
        public string Name { get; set; }

        public Guid? ContactId { get; set; }
    }
}
