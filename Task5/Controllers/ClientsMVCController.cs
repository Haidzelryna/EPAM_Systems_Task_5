
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
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Controllers
{
    public class ClientsMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ClientService _clientService = new ClientService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _clientService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Client>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new sale
        [HttpPost]
        public void Post(string values)
        {
            var newClient = new Client();
            PopulateModel(newClient, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(newClient))
            //    return Json(VALIDATION_ERROR, "400");

            _clientService.Add(newClient);
            _clientService.SaveChangesAsync();
            //return Json(result.OrderID);
        }

        // Update an sale
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var sale = await _clientService.FindAsync(key);
            PopulateModel(sale, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(order))
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _clientService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an sale
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var sale = await _clientService.FindAsync(key);
            _clientService.Remove(sale);
            await _clientService.SaveChangesAsync();
        }

        //void PopulateModel(Order order, IDictionary values)
        //{
        //    if (values.Contains("OrderID"))
        //        order.OrderID = Convert.ToInt32(values["OrderID"]);

        //    if (values.Contains("OrderDate"))
        //        order.OrderDate = values["OrderDate"] != null ? Convert.ToDateTime(values["OrderDate"]) : (DateTime?)null;

        //    if (values.Contains("ShipCity"))
        //        order.ShipCity = Convert.ToString(values["ShipCity"]);
        //}

        //[HttpGet]
        //public async Task<ActionResult> ClientLookup(DataSourceLoadOptions loadOptions)
        //{
        //    loadOptions.RequireTotalCount = false;

        //    var Clients = await _clientService.GetAllAsync();

        //    //var lookup = from i in _mapper.Map<IEnumerable<BLL.Client>>(Clients)
        //    //             orderby i.Name
        //    //             select new
        //    //             {
        //    //                 Value = i.Id,
        //    //                 Text = i.Name
        //    //             };

        //    return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Client>>(Clients), loadOptions)), JsonRequestBehavior.AllowGet);
        //    //return Json(await DataSourceLoader.LoadAsync((IQueryable)lookup, loadOptions));
        //}

        //[HttpGet]
        //public async Task<ActionResult> ManagerLookup(DataSourceLoadOptions loadOptions)
        //{
        //    var Managers = await _managerService.GetAllAsync();

        //    var lookup = from i in _mapper.Map<IEnumerable<BLL.Manager>>(Managers)
        //                 orderby i.Name
        //                 select new
        //                 {
        //                     Value = i.Id,
        //                     Text = i.Name
        //                 };

        //    return Json(await Task.Run(() => DataSourceLoader.Load(lookup, loadOptions)), JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public async Task<ActionResult> ProductLookup(DataSourceLoadOptions loadOptions)
        //{
        //    var Products = await _productService.GetAllAsync();

        //    var lookup = from i in _mapper.Map<IEnumerable<BLL.Product>>(Products)
        //                 orderby i.Name
        //                 select new
        //                 {
        //                     Value = i.Id,
        //                     Text = i.Name
        //                 };

        //    return Json(await Task.Run(() => DataSourceLoader.Load(lookup, loadOptions)), JsonRequestBehavior.AllowGet);
        //}

        private void PopulateModel(Client model, IDictionary values)
        {
            string ID = nameof(Client.Id);
            string NAME = nameof(Client.Name);
            string CONTACT_ID = nameof(Client.Contact);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(NAME))
            {
                model.Name = Convert.ToString(values[NAME]);
            }

            if (values.Contains(CONTACT_ID))
            {
                var guidClient = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)values["Contact"]).First).First).Value;
                model.ContactId = Guid.Parse(guidClient.ToString());
            }
        }

        //ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        //{
        //    Response.StatusCode = statusCode;
        //    return Content(JsonConvert.SerializeObject(obj), "application/json");
        //}

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
