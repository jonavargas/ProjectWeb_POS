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
    public class WarehouseProductsController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /WarehouseProducts/

        public ActionResult Index()
        {
            var warehouseproducts = db.WarehouseProducts.Include(w => w.Products).Include(w => w.Warehouse);
            return View(warehouseproducts.ToList());
        }

        //
        // GET: /WarehouseProducts/Details/5

        public ActionResult Details(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Create

        public ActionResult Create()
        {
            ViewBag.idProducts = new SelectList(db.Products, "id", "name");
            ViewBag.idWarehouse = new SelectList(db.Warehouse, "id", "description");
            return View();
        }

        //
        // POST: /WarehouseProducts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WarehouseProducts warehouseproducts)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseProducts.Add(warehouseproducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducts = new SelectList(db.Products, "id", "name", warehouseproducts.idProducts);
            ViewBag.idWarehouse = new SelectList(db.Warehouse, "id", "description", warehouseproducts.idWarehouse);
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducts = new SelectList(db.Products, "id", "name", warehouseproducts.idProducts);
            ViewBag.idWarehouse = new SelectList(db.Warehouse, "id", "description", warehouseproducts.idWarehouse);
            return View(warehouseproducts);
        }

        //
        // POST: /WarehouseProducts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WarehouseProducts warehouseproducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseproducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducts = new SelectList(db.Products, "id", "name", warehouseproducts.idProducts);
            ViewBag.idWarehouse = new SelectList(db.Warehouse, "id", "description", warehouseproducts.idWarehouse);
            return View(warehouseproducts);
        }

        //
        // GET: /WarehouseProducts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            if (warehouseproducts == null)
            {
                return HttpNotFound();
            }
            return View(warehouseproducts);
        }

        //
        // POST: /WarehouseProducts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            db.WarehouseProducts.Remove(warehouseproducts);
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