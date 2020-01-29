using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Services;
using AutoMapper;
using System.Threading.Tasks;

namespace Task5.Controllers
{
    public class ChartsController : Controller
    {
        private static IMapper _mapper;
        private readonly IService<BLL.Sale> _service;

        public ChartsController(IService<BLL.Sale> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ActionResult> SideBySideBar()
        {
            var bllEntities = await _service.GetAllAsync();
            return View(_mapper.Map<IEnumerable<Task5.Sale>>(bllEntities));
        }
    }
}