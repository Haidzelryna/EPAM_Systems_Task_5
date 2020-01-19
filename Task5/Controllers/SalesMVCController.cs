using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL;
using DevExtreme.AspNet.Mvc;

using DevExtreme.AspNet.Data;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task5.Models;
using DAL;

namespace Task5.Controllers
{
    public class SalesMVCController : Controller
    {
        private SalesEntities db = new SalesEntities();

        // GET: SalesMVC
        //public async Task<ActionResult> Index()
        //{
        //    var sale = db.Sale.Include(s => s.Client).Include(s => s.Manager).Include(s => s.Product);
        //    return View(await sale.ToListAsync());
        //}


        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        { 

            loadOptions.RequireTotalCount = false;

            loadOptions.Skip = 3;


            return Json(await Task.Run(() => DataSourceLoader.Load(db.Sale, loadOptions)));
        }

        //// GET: Products
        //public object Get()
        //{
        //    return db.Sale.ToList();
        //}


        //[HttpGet]
        //public IEnumerable<Sale> Get(DataSourceLoadOptions loadOptions)
        //{
        //    IEnumerable<Sale> sales = (IEnumerable<Sale>)db.Sale.ToList();


        //    return sales;
        //}


        //[Route("api/[controller]/[action]")]
        //public class OrdersController : Controller
        //{
        //NorthwindContext _context;

        //public OrdersController(NorthwindContext context)
        //{
        //    _context = context;
        //}

        //const string VALIDATION_ERROR = "The request failed due to a validation error";



    }
}
