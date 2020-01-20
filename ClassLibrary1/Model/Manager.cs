
using System;
using BLL.Model.BaseEntity;
using Newtonsoft.Json;

namespace BLL
{
    public class Manager : Entity
    {
        public string Name { get; set; }

        public Guid ContactId { get; set; }

       // [JsonIgnore]
        public Contact Contact { get; set; }
    }
}
