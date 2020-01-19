
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using Task5.Models;
using DAL;

namespace DevExtreme.MVC.Demos.Controllers
{
    public class SalesController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View("~/Views/Sales/Index.cshtml");
        //}

        //private SalesEntities db = new SalesEntities();

        // GET: Sales
        public async Task<ActionResult> Index()
        {
            //return View(await db.Sale.ToListAsync());
            return View();
        }
    }
}