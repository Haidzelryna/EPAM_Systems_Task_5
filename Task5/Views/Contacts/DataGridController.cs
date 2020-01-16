//using DevExtreme.MVC.Demos.Models;
//using DevExtreme.MVC.Demos.Models.DataGrid;
//using DevExtreme.MVC.Demos.Models.SampleData;

using System;
using System.Linq;
using System.Web.Mvc;

namespace Task5.View.Contacts
{
    public class DataGridController : Controller
    {
        public ActionResult ColumnCustomization()
        {
            return View(ContactData.DataGridContacts.Take(5));
        }
    }
}