using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

namespace DAL.Controllers
{
    public class ContactsMVCController : BaseMVCController<DAL.Contact, Contact>
    {
        public ContactsMVCController()
        {
            _service = new ContactService(_mapper);
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

        protected override void PopulateModel(Contact model, IDictionary values)
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
    }
}
