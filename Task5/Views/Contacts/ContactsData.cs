//using DevExtreme.AspNet.Mvc;
//using DevExtreme.MVC.Demos.Models.DataGrid;
using System;
using System.Collections.Generic;
using Task5.Models;

namespace Task5.Views.Contacts
{
    public partial class ContactData
    {
        public static readonly IEnumerable<Contact> DataGridContacts = new[] {
            new Contact {
                Id = new Guid(),
                FirstName = "John",
                MiddleName = "Johnich",
                LastName = "Heart",
                Phone = "(213) 555-9392",
                Email = "jheart@dx-email.com",
            },
            new Contact {
                Id = new Guid(),
                FirstName = "Olivia",
                MiddleName = "Johnich",
                LastName = "Peyton",
                Phone = "(310) 555-2728",
                Email = "oliviap@dx-email.com"
            },
            new Contact {
                Id = new Guid(),
                FirstName = "Robert",
                MiddleName = "Johnich",
                LastName = "Reagan",
                Phone = "(818) 555-2387",
                Email = "robertr@dx-email.com"                    
            },
            new Contact {
                Id = new Guid(),
                FirstName = "Greta",
                MiddleName = "Johnich",
                LastName = "Sims",
                Phone = "(818) 555-6546",
                Email = "gretas@dx-email.com"
            },
            new Contact {
                Id = new Guid(),
                FirstName = "Brett",
                MiddleName = "Johnich",
                LastName = "Wade",
                Phone = "(626) 555-0358",
                Email = "brettw@dx-email.com"
            }
        };
    }
}