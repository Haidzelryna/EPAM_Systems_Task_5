
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
        public async Task<ActionResult> Post(string values)
        {
            var newManager = new Manager();
            PopulateModel(newManager, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(newManager))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            _managerService.Add(newManager);
            await _managerService.SaveChangesAsync();
            return NewtonsoftJson(newManager.Id);
        }

        // Update an manager
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var manager = await _managerService.FindAsync(key);
            PopulateModel(manager, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(manager))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

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

        private void PopulateModel(Manager model, IDictionary values)
        {
            string ID = nameof(Manager.Id);
            string NAME = nameof(Manager.Name);
            string CONTACT_ID = nameof(Manager.Contact);

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

        ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        {
            Response.StatusCode = statusCode;
            return Content(JsonConvert.SerializeObject(obj), "application/json");
        }
    }
}
