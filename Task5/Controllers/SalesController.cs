using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using System.Collections.Generic;

//namespace DevExtreme.MVC.Demos.Controllers
namespace Task5.Controllers
{
    public class SalesController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View("~/Views/Sales/Index.cshtml");
        //}

        //private SalesEntities db = new SalesEntities();

        // GET: Sales

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);

        public async Task<ActionResult> Index()
        {
           // return View(await db.Sale.ToListAsync());
            return View();

            //var bllEntities = await _saleService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Sale>>(bllEntities));
        }
    }
}