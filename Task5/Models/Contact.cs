
using System.Collections.Generic;
using Task5.Model.BaseEntity;

namespace Task5
{
    public class Contact : Entity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
