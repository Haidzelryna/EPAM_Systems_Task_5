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
    public class ContactsMVCController : Controller
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ContactService _contactService = new ContactService(_mapper);

        // Load contacts according to load options
        [HttpGet]
        public async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _contactService.GetAllAsync();

            return Json(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<IEnumerable<BLL.Contact>>(bllEntities), loadOptions)), JsonRequestBehavior.AllowGet);
        }

        // Insert a new contact
        [HttpPost]
        public async Task<ActionResult> Post(string values)
        {
            var newContact = new Contact();
            PopulateModel(newContact, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(newContact))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            _contactService.Add(newContact);
            await _contactService.SaveChangesAsync();
            return NewtonsoftJson(newContact.Id);
        }

        // Update an contact
        [HttpPut]
        public async Task<ActionResult> Put(Guid key, string values)
        {
            var contact = await _contactService.FindAsync(key);
            PopulateModel(contact, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(contact))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            await _contactService.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an contact
        [HttpDelete]
        public async Task Delete(Guid key)
        {
            var sale = await _contactService.FindAsync(key);
            _contactService.Remove(sale);
            await _contactService.SaveChangesAsync();
        }

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

        ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        {
            Response.StatusCode = statusCode;
            return Content(JsonConvert.SerializeObject(obj), "application/json");
        }
    }
}
