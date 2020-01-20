
using System;
using Task5.Model.BaseEntity;

namespace Task5
{
    public class Sale//: BaseEntity
    {
        public DateTime? Date { get; set; }

        public string ClientName { get; set; }

        public string ProductName { get; set; }

        public string Sum { get; set; }
    }
}
