using DevExtreme.MVC.Demos.Models;
using DevExtreme.MVC.Demos.Models.DataGrid;
using DevExtreme.MVC.Demos.Models.SampleData;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Task5.Views.Sales
{
    public class DataGridController : Controller
    {
        public ActionResult ColumnCustomization()
        {
            return View(SampleData.DataGridEmployees.Take(10));
        }
    }
}