using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace POS.Controllers
{
    public class SuppliersController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /Suppliers/

        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        //
        // GET: /Suppliers/Details/5

        public ActionResult Details(int id = 0)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // GET: /Suppliers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Suppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(suppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suppliers);
        }

        //
        // GET: /Suppliers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // POST: /Suppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        //
        // GET: /Suppliers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // POST: /Suppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            db.Suppliers.Remove(suppliers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}