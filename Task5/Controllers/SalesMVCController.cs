
using System.Threading.Tasks;
using System.Web.Mvc;
using DevExtreme.AspNet.Mvc;

using DevExtreme.AspNet.Data;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using System.Collections.Generic;

using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Controllers
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

        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        //80ab7036-5d4a-11e6-9903-0050569977a1

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);
        private readonly ClientService _clientService = new ClientService(_mapper);
        private readonly ManagerService _managerService = new ManagerService(_mapper);
        private readonly ProductService _productService = new ProductService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _saleService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Sale>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new order
        [HttpPost]
        public void Post(string values)
        {
            var newSale = new Sale();
            PopulateModel(newSale, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(newSale))
            //    return Json(VALIDATION_ERROR, "400");

            newSale.CreatedByUserId = adminGuid;
            newSale.CreatedDateTime = DateTime.UtcNow;

            _saleService.Add(newSale);
            _saleService.SaveChangesAsync();
            //return Json(result.OrderID);
        }

        //// Update an order
        //[HttpPut]
        //public void Put(int key, string values)
        //{
        //    var order = await _saleService.FirstOrDefaultAsync(item => item.OrderID == key);
        //    PopulateModel(order, JsonConvert.DeserializeObject<IDictionary>(values));

        //    if (!TryValidateModel(order))
        //        return NewtonsoftJson(VALIDATION_ERROR, 400);

        //    await _context.SaveChanges;
        //    //return new EmptyResult();
        //}

        //// Remove an order
        //[HttpDelete]
        //public async Task Delete(int key)
        //{
        //    var order = await _context.Orders.FirstOrDefaultAsync(item => item.OrderID == key);
        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();
        //}

        //void PopulateModel(Order order, IDictionary values)
        //{
        //    if (values.Contains("OrderID"))
        //        order.OrderID = Convert.ToInt32(values["OrderID"]);

        //    if (values.Contains("OrderDate"))
        //        order.OrderDate = values["OrderDate"] != null ? Convert.ToDateTime(values["OrderDate"]) : (DateTime?)null;

        //    if (values.Contains("ShipCity"))
        //        order.ShipCity = Convert.ToString(values["ShipCity"]);
        //}


        private void PopulateModel(Sale model, IDictionary values)
        {
            string ID = nameof(Sale.Id);
            string CLIENT_ID = nameof(Sale.Client);
            string PRODUCT_ID = nameof(Sale.Product);
            string SUM = nameof(Sale.Sum);
            string DATE = nameof(Sale.Date);
            string CLIENT_NAME = nameof(Sale.ClientName);
            string PRODUCT_NAME = nameof(Sale.ProductName);
            string CREATED_BY_USER_ID = nameof(Sale.CreatedByUserId);
            string CREATED_DATE_TIME = nameof(Sale.CreatedDateTime);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(CLIENT_ID))
            {
                var guidClient = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)values["Client"]).First).First).Value;
                model.ClientId = Guid.Parse(guidClient.ToString());
            }

            if (values.Contains(PRODUCT_ID))
            {
                var guidProduct = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)values["Product"]).First).First).Value;
                model.ProductId = Guid.Parse(guidProduct.ToString());
            }

            if (values.Contains(SUM))
            {
                model.Sum = Convert.ToDecimal(values[SUM]);
            }

            if (values.Contains(DATE))
            {
                model.Date = Convert.ToDateTime(values[DATE]);
            }

            if (values.Contains(CLIENT_NAME))
            {
                model.ClientName = Convert.ToString(values[CLIENT_NAME]);
            }

            if (values.Contains(PRODUCT_NAME))
            {
                model.ProductName = Convert.ToString(values[PRODUCT_NAME]);
            }

            if (values.Contains(CREATED_BY_USER_ID))
            {
                model.CreatedByUserId = Guid.Parse(values[CREATED_BY_USER_ID].ToString());
            }

            if (values.Contains(CREATED_DATE_TIME))
            {
                model.CreatedDateTime = Convert.ToDateTime(values[CREATED_DATE_TIME]);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
