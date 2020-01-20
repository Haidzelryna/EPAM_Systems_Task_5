using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services;

namespace DAL.Controllers
{
    public class ManagersController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ManagerService _managerService = new ManagerService(_mapper);

        // GET: Managers
        public async Task<ActionResult> Index()
        {
            //var bllEntities = await _managerService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Manager>>(bllEntities));

            return View();
        }
    }
}
