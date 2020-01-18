//using DevExtreme.MVC.Demos.Models;
//using DevExtreme.MVC.Demos.Models.DataGrid;
//using DevExtreme.MVC.Demos.Models.SampleData;



using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Task5.Models;
using Task5.Controllers;
using System.Threading.Tasks;

using System.Data.Entity;

using System.Net;

using DAL;


namespace Task5.Controllers
{
    public class ContactsController : Controller
    {
        //For DevExtreme
        //public ActionResult ColumnCustomization()
        //{
        //    return View(db.Contact.ToListAsync());
        //}

        private SalesEntities db = new SalesEntities();

        // GET: Contacts
        public ActionResult Index()
        {
            //return View(await db.Contact.ToListAsync());

            return View((IEnumerable<Contact>)db.Contact.ToList());
        }

        // GET: Contacts/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = await db.Contact.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// GET: Contacts/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Phone,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = Guid.NewGuid();
                db.Contact.Add(contact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contact.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Phone,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contact.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Contact contact = await db.Contact.FindAsync(id);
            db.Contact.Remove(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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