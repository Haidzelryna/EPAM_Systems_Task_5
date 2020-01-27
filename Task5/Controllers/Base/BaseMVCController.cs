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

namespace Task5.Controllers
{
    public abstract class BaseMVCController<T,V> : Controller
        where T: BLL.Entity, new()
        where V: Task5.Entity, new()
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";
        const string VALID_ERROR = "Data failed validation";

        protected static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        protected static IService<T> _service;// = new EntityService(_mapper);

        // Load orders according to load options
        [HttpGet]
        public virtual async Task<ActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = false;

            var bllEntities = await _service.GetAllAsync();

            return NewtonsoftJson(await Task.Run(() => DataSourceLoader.Load(_mapper.Map<ICollection<V>>(bllEntities), loadOptions)));
        }

        ActionResult NewtonsoftJson(object obj, int statusCode = 200)
        {
            Response.StatusCode = statusCode;
            return Content(JsonConvert.SerializeObject(obj), "application/json");
        }

        // Insert a new entity
        [HttpPost]
        public virtual async Task<ActionResult> Post(string values)
        {
            var newEntity = new T();

            PopulateModel(newEntity, JsonConvert.DeserializeObject<IDictionary>(values));

           
            if (!TryValidateModel(newEntity))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            Validation(newEntity, ModelState);

            if (!ModelState.IsValid)
                return NewtonsoftJson(VALID_ERROR, 400);

            _service.Add(newEntity);
            await _service.SaveChangesAsync();
            return NewtonsoftJson(newEntity.Id);
        }

        // Update an entity
        [HttpPut]
        public virtual async Task<ActionResult> Put(Guid key, string values)
        {
            var entity = await _service.FindAsync(key);
            PopulateModel(entity, JsonConvert.DeserializeObject<IDictionary>(values));

            if (!TryValidateModel(entity))
                return NewtonsoftJson(VALIDATION_ERROR, 400);

            _service.Update(entity);
            await _service.SaveChangesAsync();
            return new EmptyResult();
        }

        // Remove an entity
        [HttpDelete]
        public virtual async Task Delete(Guid key)
        {
            var entity = await _service.FindAsync(key);
            _service.Remove(entity);
            await _service.SaveChangesAsync();
        }

        protected abstract void PopulateModel(T model, IDictionary values);

        protected abstract void Validation(T model, ModelStateDictionary modelState);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //
            }
            base.Dispose(disposing);
        }
    }
}
