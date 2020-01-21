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
    public class ClientsMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ClientService _clientService = new ClientService(_mapper);

        // Load clients according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _clientService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Client>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new client
        [HttpPost]
        public async Task<ActionResult> Post(string values)
        {
            var newClient = new Client();
            PopulateModel(newClient, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(newClient))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            _clientService.Add(newClient);
            await _clientService.SaveChangesAsync();
            return NewtonsoftJson(newClient.Id);
        }

        // Update an client
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var client = await _clientService.FindAsync(key);
            PopulateModel(client, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(client))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _clientService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an client
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var sale = await _clientService.FindAsync(key);
            _clientService.Remove(sale);
            await _clientService.SaveChangesAsync();
        }

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

        ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        {
            Response.StatusCode = statusCode;
            return Content(JsonConvert.SerializeObject(obj), "application/json");
        }
    }
}
