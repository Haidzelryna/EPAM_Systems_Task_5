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
            //var manager = db.Manager.Include(m => m.Contact);
            //return View(await manager.ToListAsync());

            //var bllEntities = await _managerService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<BLL.Manager>>(bllEntities));

            return View();
        }

        //// GET: Managers/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Manager manager = await db.Manager.FindAsync(id);
        //    if (manager == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(manager);
        //}

        //// GET: Managers/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName");
        //    return View();
        //}

        //// POST: Managers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,ContactId")] Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        manager.Id = Guid.NewGuid();
        //        db.Manager.Add(manager);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", manager.ContactId);
        //    return View(manager);
        //}

        //// GET: Managers/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Manager manager = await db.Manager.FindAsync(id);
        //    if (manager == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", manager.ContactId);
        //    return View(manager);
        //}

        //// POST: Managers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ContactId")] Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(manager).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", manager.ContactId);
        //    return View(manager);
        //}

        //// GET: Managers/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Manager manager = await db.Manager.FindAsync(id);
        //    if (manager == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(manager);
        //}

        //// POST: Managers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    Manager manager = await db.Manager.FindAsync(id);
        //    db.Manager.Remove(manager);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
