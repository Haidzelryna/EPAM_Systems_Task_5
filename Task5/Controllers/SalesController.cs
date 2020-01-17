
using System.Web.Mvc;

namespace DevExtreme.MVC.Demos.Controllers
{
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Sales/Sales.cshtml");
        }
    }
}