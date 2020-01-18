using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Task5.Models.Controllers
{
    [Route("api/Client/{action}", Name = "ClientsWebApi")]
    public class ClientsWebApiController : ApiController
    {
        private SalesEntities _context = new SalesEntities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {
            var client = _context.Client.Select(i => new {
                i.Id,
                i.ContactId,
                i.Name
            });
            return Request.CreateResponse(DataSourceLoader.Load(client, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form) {
            var model = new Client();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.Client.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.Id);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form) {
            var key = Guid.Parse(form.Get("key"));
            var model = _context.Client.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Client not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(FormDataCollection form) {
            var key = Guid.Parse(form.Get("key"));
            var model = _context.Client.FirstOrDefault(item => item.Id == key);

            _context.Client.Remove(model);
            _context.SaveChanges();
        }


        [HttpGet]
        public HttpResponseMessage ContactLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Contact
                         orderby i.FirstName
                         select new {
                             Value = i.Id,
                             Text = i.FirstName
                         };
            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        private void PopulateModel(Client model, IDictionary values) {
            string ID = nameof(Client.Id);
            string CONTACT_ID = nameof(Client.ContactId);
            string NAME = nameof(Client.Name);

            if(values.Contains(ID)) {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if(values.Contains(CONTACT_ID)) {
                model.ContactId = Guid.Parse(values[CONTACT_ID].ToString());
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}