using System.Web.Mvc;
using AutoMapper;
using BLL.Services;
using System.Threading.Tasks;

namespace Task5.Controllers
{
    public class ProductsController : Controller
    {      
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ProductService _productService = new ProductService(_mapper);

        //GET: Products
        public async Task<ActionResult> Index()
        {
            //var bllEntities = await _productService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Product>>(bllEntities));

            return View();
        }
    }
}
