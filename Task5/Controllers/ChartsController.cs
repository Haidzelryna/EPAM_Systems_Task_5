using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Services;
using AutoMapper;
using System.Threading.Tasks;

namespace Task5.Controllers
{
    public class ChartsController : Controller
    {
        private static IMapper _mapper = UnityConfig.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);

        public async Task<ActionResult> SideBySideBar()
        {
            var bllEntities = await _saleService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<Task5.Sale>>(bllEntities));
        }
    }
}