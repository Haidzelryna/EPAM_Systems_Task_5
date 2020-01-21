using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

namespace DAL.Controllers
{
    public class SalesMVCController : BaseMVCController<DAL.Sale, BLL.Sale>
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

        protected override void PopulateModel(DAL.Sale model, IDictionary values)
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
                //var guidClient = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)values["Client"]).First).First).Value;
                //model.ClientId = Guid.Parse(guidClient.ToString());
                model.ClientId = Guid.Parse(values[CLIENT_ID].ToString());
            }

            if (values.Contains(PRODUCT_ID))
            {
                //var guidProduct = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)values["Product"]).First).First).Value;
                //model.ProductId = Guid.Parse(guidProduct.ToString());
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
    }
}
