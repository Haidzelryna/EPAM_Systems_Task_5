
using System;

namespace BLL
{
    public class Contact : Entity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {MiddleName} {LastName}"; } }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
