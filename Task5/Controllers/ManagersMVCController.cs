﻿
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
    public class ManagersMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ManagerService _managerService = new ManagerService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _managerService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Manager>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new manager
        [HttpPost]
        public void Post(string values)
        {
            var newManager = new Manager();
            PopulateModel(newManager, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(newManager))
            //    return Json(VALIDATION_ERROR, "400");

            _managerService.Add(newManager);
            _managerService.SaveChangesAsync();
            //return Json(result.OrderID);
        }

        // Update an manager
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var manager = await _managerService.FindAsync(key);
            PopulateModel(manager, JsonConvert.DeserializeObject<IDictionary>(values));

            //if (!TryValidateModel(order))
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _managerService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an manager
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var manager = await _managerService.FindAsync(key);
            _managerService.Remove(manager);
            await _managerService.SaveChangesAsync();
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


        private void PopulateModel(Manager model, IDictionary values)
        {
            string ID = nameof(Manager.Id);
            string NAME = nameof(Manager.Name);
            string CONTACT_ID = nameof(Manager.ContactId);

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
                model.ContactId = Guid.Parse(values[CONTACT_ID].ToString());
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