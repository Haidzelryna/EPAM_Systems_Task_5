using System.Web.Mvc;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class ContactsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }   
    }
}