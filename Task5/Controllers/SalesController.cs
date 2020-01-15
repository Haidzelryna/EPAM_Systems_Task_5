using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task5.Models;

namespace Task5.Controllers
{
    public class SalesController : Controller
    {
        private SalesEntities db = new SalesEntities();

        // GET: Sales
        public async Task<ActionResult> Index()
        {
            var sale = db.Sale.Include(s => s.Client).Include(s => s.Manager).Include(s => s.Product);
            return View(await sale.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sale.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name");
            ViewBag.CreatedByUserId = new SelectList(db.Manager, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClientId,ProductId,Sum,Date,ClientName,ProductName,CreatedByUserId,CreatedDateTime")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                sale.Id = Guid.NewGuid();
                db.Sale.Add(sale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", sale.ClientId);
            ViewBag.CreatedByUserId = new SelectList(db.Manager, "Id", "Name", sale.CreatedByUserId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sale.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", sale.ClientId);
            ViewBag.CreatedByUserId = new SelectList(db.Manager, "Id", "Name", sale.CreatedByUserId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", sale.ProductId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClientId,ProductId,Sum,Date,ClientName,ProductName,CreatedByUserId,CreatedDateTime")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", sale.ClientId);
            ViewBag.CreatedByUserId = new SelectList(db.Manager, "Id", "Name", sale.CreatedByUserId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Name", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = await db.Sale.FindAsync(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Sale sale = await db.Sale.FindAsync(id);
            db.Sale.Remove(sale);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
