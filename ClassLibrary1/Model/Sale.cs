
using System;
using BLL.Model.BaseEntity;
using Newtonsoft.Json;

namespace BLL
{
    public class Sale: BaseEntity
    {
        public DateTime Date { get; set; }

        public string Sum { get; set; }

        public System.Guid ClientId { get; set; }

        public System.Guid ProductId { get; set; }
    }
}
