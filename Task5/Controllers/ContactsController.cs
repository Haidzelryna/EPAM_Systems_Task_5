using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Task5.Models;

namespace DAL.Controllers
{
    public class ContactsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (user.Roles.Where(r => r.RoleId == "1").Any())
            {
                return View();
            }

            return View("IndexReadOnly");
        }   
    }
}