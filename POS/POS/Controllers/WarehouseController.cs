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
    public class WarehouseController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /Warehouse/

        public ActionResult Index()
        {
            return View(db.Warehouse.ToList());
        }

        //
        // GET: /Warehouse/Details/5

        public ActionResult Details(int id = 0)
        {
            Warehouse warehouse = db.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // GET: /Warehouse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Warehouse/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Warehouse.Add(warehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        //
        // GET: /Warehouse/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Warehouse warehouse = db.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // POST: /Warehouse/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        //
        // GET: /Warehouse/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Warehouse warehouse = db.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // POST: /Warehouse/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouse warehouse = db.Warehouse.Find(id);
            db.Warehouse.Remove(warehouse);
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