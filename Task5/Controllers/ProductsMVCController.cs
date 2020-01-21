﻿using System;
using System.Collections;
using System.Web.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using BLL.Services;

namespace DAL.Controllers
{
    public class ProductsMVCController : BaseMVCController<DAL.Product, BLL.Product>
    {
        public ProductsMVCController()
        {
            _service = new ProductService(_mapper);
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

        protected override void PopulateModel(DAL.Product model, IDictionary values)
        {
            string ID = nameof(Product.Id);
            string NAME = nameof(Product.Name);
            string PRICE = nameof(Product.Price);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(NAME))
            {
                model.Name = Convert.ToString(values[NAME]);
            }

            if (values.Contains(PRICE))
            {
                model.Price = Convert.ToDecimal(values[PRICE]);
            }
        }
    }
}
