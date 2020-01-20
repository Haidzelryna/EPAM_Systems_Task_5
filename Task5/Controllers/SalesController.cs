using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;

namespace Task5.Controllers
{
    public class SalesController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);

        public async Task<ActionResult> Index()
        {
            return View();

            //var bllEntities = await _saleService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Sale>>(bllEntities));
        }
    }
}