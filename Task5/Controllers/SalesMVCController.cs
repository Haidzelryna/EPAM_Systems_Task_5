using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

using Newtonsoft.Json;
using DevExtreme.AspNet.Data;
using AutoMapper;

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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Task5.Models;

using System.Linq;

namespace Task5.Controllers
{
    public class SalesMVCController : BaseMVCController<BLL.Sale, Sale>
    {
        public SalesMVCController()
        {
            _service = new SaleService(_mapper);
        }

        public SalesMVCController(IService<BLL.Sale> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
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
        public override async Task<ActionResult> Post(string values)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            var managerService = new ManagerService(_mapper);

            var managers = managerService.GetAllAsync().Result;

            var newEntity = new BLL.Sale();

            PopulateModel(newEntity, JsonConvert.DeserializeObject<IDictionary>(values));


            //if (!TryValidateModel(newEntity))
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            //if (!ModelState.IsValid)
            //    return NewtonsoftJson(VALIDATION_ERROR, 400);

            Validation(newEntity, ModelState);

            if (newEntity is BLL.Sale)
            {
                (newEntity as BLL.Sale).CreatedByUserId = managers.Where(m => m.UserId == user.Id).First().Id;
                (newEntity as BLL.Sale).CreatedDateTime = DateTime.UtcNow;
                //(newEntity as BLL.BaseEntity).CreatedByUserId = adminGuid;
                //(newEntity as BLL.BaseEntity).CreatedDateTime = DateTime.UtcNow;
            }

            _service.Add(newEntity);

            await _service.SaveChangesAsync();
            return NewtonsoftJson(newEntity.Id);
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

        protected override void PopulateModel(BLL.Sale model, IDictionary values)
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
                model.Sum = Convert.ToString(values[SUM]);
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

        protected override void Validation(BLL.Sale model, ModelStateDictionary modelState)
        {
            if (model.Sum.Length > 15)
            {
                ModelState.AddModelError("Summa", "Недопустимая длина суммы");
            }
        }
    }
}
