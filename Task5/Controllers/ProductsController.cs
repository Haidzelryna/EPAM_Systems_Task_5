using System.Web.Mvc;
using System.Threading.Tasks;

namespace Task5.Controllers
{
    public class ProductsController : Controller
    {      
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
