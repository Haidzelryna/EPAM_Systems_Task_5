
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

//namespace DevExtreme.MVC.Demos.Controllers
namespace Task5.Controllers
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