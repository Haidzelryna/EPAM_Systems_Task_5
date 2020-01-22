using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Controllers
{
    public class ClientsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
