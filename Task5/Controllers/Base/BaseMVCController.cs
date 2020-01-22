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

namespace DAL.Controllers
{
    public abstract class BaseMVCController<T,V> : Controller 
        where T: DAL.Entity, new()
        where V: Entity, new()
    {
        private const string ADMINID = "80AB7036-5D4A-11E6-9903-0050569977A1";
        private static Guid adminGuid = Guid.Parse(ADMINID);

        const string VALIDATION_ERROR = "The request failed due to a validation error";

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

            if (newEntity is DAL.Sale)
            {
                (newEntity as DAL.Sale).CreatedByUserId = adminGuid;
                (newEntity as DAL.Sale).CreatedDateTime = DateTime.UtcNow;
                (newEntity as DAL.BaseEntity).CreatedByUserId = adminGuid;
                (newEntity as DAL.BaseEntity).CreatedDateTime = DateTime.UtcNow;
            }

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
