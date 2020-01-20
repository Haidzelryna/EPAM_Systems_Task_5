
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
    public class ContactsMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ContactService _contactService = new ContactService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _contactService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Contact>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new sale
        [HttpPost]
        public void Post(string values)
        {
            var newContact = new Contact();
            PopulateModel(newContact, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(newContact))
            //    return Json(VALIDATION_ERROR, "400");

            _contactService.Add(newContact);
            _contactService.SaveChangesAsync();
            //return Json(result.OrderID);
        }

        // Update an sale
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var sale = await _contactService.FindAsync(key);
            PopulateModel(sale, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(order))
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _contactService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an sale
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var sale = await _contactService.FindAsync(key);
            _contactService.Remove(sale);
            await _contactService.SaveChangesAsync();
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
        //public async Task<ActionResult> ContactLookup(DataSourceLoadOptions loadOptions)
        //{
        //    loadOptions.RequireTotalCount = false;

        //    var Contacts = await _contactService.GetAllAsync();

        //    //var lookup = from i in _mapper.Map<IEnumerable<BLL.Contact>>(Contacts)
        //    //             orderby i.Name
        //    //             select new
        //    //             {
        //    //                 Value = i.Id,
        //    //                 Text = i.Name
        //    //             };

        //    return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Contact>>(Contacts), loadOptions)), JsonRequestBehavior.AllowGet);
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

        private void PopulateModel(Contact model, IDictionary values)
        {
            string ID = nameof(Contact.Id);
            string FIRSTNAME = nameof(Contact.FirstName);
            string LASTNAME = nameof(Contact.LastName);
            string MIDDLENAME = nameof(Contact.MiddleName);
            string EMAIL = nameof(Contact.Email);
            string PHONE = nameof(Contact.Phone);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(FIRSTNAME))
            {
                model.FirstName = Convert.ToString(values[FIRSTNAME]);
            }

            if (values.Contains(LASTNAME))
            {
                model.LastName = Convert.ToString(values[LASTNAME]);
            }

            if (values.Contains(MIDDLENAME))
            {
                model.MiddleName = Convert.ToString(values[MIDDLENAME]);
            }

            if (values.Contains(EMAIL))
            {
                model.Email = Convert.ToString(values[EMAIL]);
            }

            if (values.Contains(PHONE))
            {
                model.Phone = Convert.ToString(values[PHONE]);
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
