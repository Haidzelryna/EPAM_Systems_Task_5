using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;

namespace DAL.Controllers
{
    public class ContactsController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ContactService _contactService = new ContactService(_mapper);

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            //var bllEntities = await _contactService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Contact>>(bllEntities));

            return View();
        }   
    }
}