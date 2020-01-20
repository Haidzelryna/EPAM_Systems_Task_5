using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Services;
using AutoMapper;

namespace DAL.Controllers
{
    public class ClientsController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ClientService _clientService = new ClientService(_mapper);

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            //var bllEntities = await _clientService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Client>>(bllEntities));
            return View();
        }
    }
}
