using System.Threading.Tasks;
using System.Web.Mvc;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Services;
using System.Collections;

namespace DAL.Controllers
{
    public class SalesMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _saleService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Sale>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        //ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        //{
        //    Response.StatusCode = statusCode;
        //    return Content(JsonConvert.SerializeObject(obj), "application/json");
        //}

        // Insert a new sale
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

        // Update an sale
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var sale = await _saleService.FindAsync(key);
            PopulateModel(sale, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(order))
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _saleService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an sale
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var sale = await _saleService.FindAsync(key);
            _saleService.Remove(sale);
            await _saleService.SaveChangesAsync();
        }

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //
            }
            base.Dispose(disposing);
        }
    }
}
