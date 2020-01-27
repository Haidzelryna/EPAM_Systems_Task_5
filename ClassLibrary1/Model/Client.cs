
using System;
using Newtonsoft.Json;

namespace BLL
{
    public class Client : Entity
    {
        public string Name { get; set; }

        public Guid? ContactId { get; set; }

        //public Contact Contact { get; set; }
    }
}
