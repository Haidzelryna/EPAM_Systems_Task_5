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
using Task5.Models;
using DAL;

namespace Task5.Controllers
{
    [Route("api/SalesWebApi/{action}", Name = "SalesWebApi")]
    public class SalesWebApiController : ApiController
    {
        private SalesEntities _context = new SalesEntities();

        public SalesWebApiController()
        {

        }

        public SalesWebApiController(SalesEntities context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/SalesWebApi/{loadOptions}")]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            var sale = _context.Sale.Select(i => new
            {
                i.Id,
                i.ClientId,
                i.ProductId,
                i.Sum,
                i.Date,
                i.ClientName,
                i.ProductName,
                i.CreatedByUserId,
                i.CreatedDateTime
            });
            return Request.CreateResponse(DataSourceLoader.Load(sale, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            var model = new Sale();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            var result = _context.Sale.Add(model);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, result.Id);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            var key = Guid.Parse(form.Get("key"));
            var model = _context.Sale.FirstOrDefault(item => item.Id == key);
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Sale not found");

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateModel(model, values);

            Validate(model);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(FormDataCollection form)
        {
            var key = Guid.Parse(form.Get("key"));
            var model = _context.Sale.FirstOrDefault(item => item.Id == key);

            _context.Sale.Remove(model);
            _context.SaveChanges();
        }


        [HttpGet]
        public HttpResponseMessage ClientLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Client
                         orderby i.Name
                         select new
                         {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage ManagerLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Manager
                         orderby i.Name
                         select new
                         {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage ProductLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Product
                         orderby i.Name
                         select new
                         {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Request.CreateResponse(DataSourceLoader.Load(lookup, loadOptions));
        }

        private void PopulateModel(Sale model, IDictionary values)
        {
            string ID = nameof(Sale.Id);
            string CLIENT_ID = nameof(Sale.ClientId);
            string PRODUCT_ID = nameof(Sale.ProductId);
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
                model.ClientId = Guid.Parse(values[CLIENT_ID].ToString());
            }

            if (values.Contains(PRODUCT_ID))
            {
                model.ProductId = Guid.Parse(values[PRODUCT_ID].ToString());
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

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}