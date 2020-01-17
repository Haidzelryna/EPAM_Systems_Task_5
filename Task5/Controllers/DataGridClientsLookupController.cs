using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System.Net.Http;
using System.Web.Http;
using Task5.Models;

namespace Task5.Controllers
{
    public class DataGridClientsLookupController : ApiController
    {
        SalesEntities se = new SalesEntities();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(se.Sale, loadOptions));
        }
    }
}
