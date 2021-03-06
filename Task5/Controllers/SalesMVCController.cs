﻿using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;
using Newtonsoft.Json;
using AutoMapper;
using System.Linq;

namespace Task5.Controllers
{
    public class SalesMVCController : BaseMVCController<BLL.Sale, Sale>
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        const string VALID_ERROR = "Data failed validation";
        const string SUM_ERROR = "Invalid sum length";

        public SalesMVCController()
        {

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
            var newEntity = new BLL.Sale();

            PopulateModel(newEntity, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(newEntity))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            Validation(newEntity, ModelState);

            if (!ModelState.IsValid)
                return NewtonsoftJson(SUM_ERROR, 400);

            if (newEntity is BLL.Sale)
            {
                (newEntity as BLL.Sale).CreatedDateTime = DateTime.UtcNow;
            }

            try
            {
                _service.Add(newEntity);
                await _service.SaveChangesAsync();
            }
            catch (AutoMapperMappingException ex)
            {
                return NewtonsoftJson(VALID_ERROR, 400);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{ex.Message}", ex);
            }

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
                ModelState.AddModelError("Summa", "Invalid sum length");
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDataForChart()
        {
            var bllEntities = await _service.GetAllAsync();

            var task5Entities = bllEntities.GroupBy(g => g.Date)
                                           .Select(g => new
                                           {
                                               Date = g.Key,
                                               Count = g.Count()
                                           });

            var item = task5Entities.Select(x => new object[] { x.Date.ToString(), x.Count }).ToArray();

            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
