using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Task5.Models;

namespace Task5.Controllers
{
    public class SalesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (user != null)
            {
                if (user.Roles.Where(r => r.RoleId == "1").Any())
                {
                    return View();
                }
            }

            //return View("IndexReadOnly");
            return View();
        }
    }
}