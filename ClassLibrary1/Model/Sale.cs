
using System;
using BLL.Model.BaseEntity;
using Newtonsoft.Json;

namespace BLL
{
    public class Sale: BaseEntity
    {
        public DateTime Date { get; set; }

        public string ClientName { get; set; }

        public string ProductName { get; set; }

        public string Sum { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public virtual Manager Manager { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
