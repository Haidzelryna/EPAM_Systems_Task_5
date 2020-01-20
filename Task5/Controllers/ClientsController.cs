using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

using BLL.Services;
using AutoMapper;

namespace DAL.Controllers
{
    public class ClientsController : Controller
    {
        private static IMapper _mapper = BLL.Mapper.SetupMapping.SetupMapper();
        private readonly ClientService _clientService = new ClientService(_mapper);

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            var bllEntities = await _clientService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<BLL.Client>>(bllEntities));
        }

        // GET: Clients/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Client client = await db.Client.FindAsync(id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(client);
        //}

        //GET: Clients/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName");
        //    return View();
        //}

        //POST: Clients/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,ContactId,Name")] Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        client.Id = Guid.NewGuid();
        //        db.Client.Add(client);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", client.ContactId);
        //    return View(client);
        //}

        //GET: Clients/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Client client = await db.Client.FindAsync(id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", client.ContactId);
        //    return View(client);
        //}

        //POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,ContactId,Name")] Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(client).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ContactId = new SelectList(db.Contact, "Id", "FirstName", client.ContactId);
        //    return View(client);
        //}

        //GET: Clients/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Client client = await db.Client.FindAsync(id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(client);
        //}

        //POST: Clients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    Client client = await db.Client.FindAsync(id);
        //    db.Client.Remove(client);
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
