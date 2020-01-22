using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

using Newtonsoft.Json;
using DevExtreme.AspNet.Data;

namespace DAL.Controllers
{
    public class SalesMVCController : BaseMVCController<DAL.Sale, Sale>
    {
        public SalesMVCController()
        {
            _service = new SaleService(_mapper);
        }

        [HttpGet]
        public override Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            return base.Get(loadOptions);
        }

        ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        {
            Response.StatusCode = statusCode;
            return Content(JsonConvert.SerializeObject(obj), "application/json");
        }

        [HttpPost]
        public override Task<ActionResult> Post(string values)
        {
            return base.Post(values);
        }

        [HttpPut]
        public override Task<ActionResult> Put(Guid key, string values)
        {
            return base.Put(key, values);
        }

        [HttpDelete]
        public override Task Delete(Guid key)
        {
            return base.Delete(key);
        }

        protected override void PopulateModel(Sale model, IDictionary values)
        {
            string ID = nameof(Sale.Id);
            string CLIENT_ID = nameof(Sale.ClientId);
            string PRODUCT_ID = nameof(Sale.ProductId);
            string SUM = nameof(Sale.Sum);
            string DATE = nameof(Sale.Date);
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

            if (values.Contains(CREATED_BY_USER_ID))
            {
                model.CreatedByUserId = Guid.Parse(values[CREATED_BY_USER_ID].ToString());
            }

            if (values.Contains(CREATED_DATE_TIME))
            {
                model.CreatedDateTime = Convert.ToDateTime(values[CREATED_DATE_TIME]);
            }
        }

        //public void Validation(DAL.Sale model, ModelState modelState)
        //{
        //    if (string.IsNullOrEmpty(model.Sum))
        //    {
        //        modelState.AddModelError("Name", "SM!");
        //    }
        //    //else if (person.Name.Length > 5)
        //    //{
        //    //    ModelState.AddModelError("Name", "Недопустимая длина строки");
        //    //}
        //    //if (ModelState.IsValid)
        //    //{
        //    //    return Content($"{person.Name} - {person.Email}");
        //    //}

        //    //return View(person);
        //}
    }
}
