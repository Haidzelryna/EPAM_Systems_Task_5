using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;
using AutoMapper;
using BLL;

namespace Task5.Controllers
{
    public class ContactsMVCController : BaseMVCController<BLL.Contact, Contact>
    {
        public ContactsMVCController()
        {
            _service = new ContactService(_mapper);
        }

        public ContactsMVCController(IService<BLL.Contact> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
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

        protected override void PopulateModel(BLL.Contact model, IDictionary values)
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

        protected override void Validation(BLL.Contact model, ModelStateDictionary modelState)
        {
            //if (string.IsNullOrEmpty(model.Sum))
            //{
            //    modelState.AddModelError("Name", "SM!");
            //}
            //else if (person.Name.Length > 5)
            //{
            //    ModelState.AddModelError("Name", "Недопустимая длина строки");
            //}
            //if (model.Sum.Length > 15)
            //{
            //    ModelState.AddModelError("Summa", "Недопустимая длина суммы");
            //}
            //if (ModelState.IsValid)
            //{
            //    return Content($"{person.Name} - {person.Email}");
            //}
            //if (ModelState.IsValid)
            //{
            //    return Content($"{model.Date}");
            //}
        }
    }
}
