using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
//using DevExtreme.MVC.Demos.Models.SampleData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Services;
using AutoMapper;
using System.Threading.Tasks;

namespace DevExtreme.MVC.Demos.Controllers
{
    public class ChartsController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly SaleService _saleService = new SaleService(_mapper);

        public async Task<ActionResult> SideBySideBar()
        {
            var bllEntities = await _saleService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<Task5.Sale>>(bllEntities));
        }
    }
}