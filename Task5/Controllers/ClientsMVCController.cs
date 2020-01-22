using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

namespace DAL.Controllers
{
    public class ClientsMVCController : BaseMVCController<DAL.Client>
    {
        public ClientsMVCController()
        {
            _service = new ClientService(_mapper);
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

        protected override void PopulateModel(DAL.Client model, IDictionary values)
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
    }
}
