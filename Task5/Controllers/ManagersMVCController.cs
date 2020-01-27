using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Task5.Models;
using DevExtreme.AspNet.Data;

namespace Task5.Controllers
{
    public class ManagersMVCController : BaseMVCController<BLL.Manager, Manager>
    {
        public ManagersMVCController()
        {
            _service = new ManagerService(_mapper);
        }

        public ManagersMVCController(IService<BLL.Manager> service, IMapper mapper)
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

        protected override void PopulateModel(BLL.Manager model, IDictionary values)
        {
            string ID = nameof(Manager.Id);
            string NAME = nameof(Manager.Name);
            string CONTACT_ID = nameof(Manager.ContactId);
            string USER_ID = nameof(Manager.UserId);

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
                model.ContactId = Guid.Parse(values[CONTACT_ID].ToString());
            }

            if (values.Contains(USER_ID))
            {
                model.UserId = Convert.ToString(values[USER_ID]);
            }
        }

        protected override void Validation(BLL.Manager model, ModelStateDictionary modelState)
        {
            
        }

        [HttpGet]
        public async Task<ActionResult> UsersLookup(DataSourceLoadOptions loadOptions)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            var Users = userManager.Users;

            //return Request.CreateResponse(DataSourceLoader.Load(Users, loadOptions));
            return Json(await Task.Run(() => DataSourceLoader.Load(Users, loadOptions)), JsonRequestBehavior.AllowGet);
        }
    }
}
