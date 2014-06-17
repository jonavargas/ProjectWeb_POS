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
    public class ProductSuppliersController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /ProductSppliers/

        public ActionResult Index()
        {
            var productsuppliers = db.ProductSuppliers.Include(p => p.Products).Include(p => p.Suppliers);
            return View(productsuppliers.ToList());
        }

        //
        // GET: /ProductSppliers/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsuppliers);
        }

        //
        // GET: /ProductSppliers/Create

        public ActionResult Create()
        {
            ViewBag.products_Id = new SelectList(db.Products, "id", "name");
            ViewBag.suppliers_Id = new SelectList(db.Suppliers, "id", "name");
            return View();
        }

        //
        // POST: /ProductSppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSuppliers productsuppliers)
        {
            if (ModelState.IsValid)
            {
                db.ProductSuppliers.Add(productsuppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.products_Id = new SelectList(db.Products, "id", "name", productsuppliers.products_Id);
            ViewBag.suppliers_Id = new SelectList(db.Suppliers, "id", "name", productsuppliers.suppliers_Id);
            return View(productsuppliers);
        }

        //
        // GET: /ProductSppliers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            ViewBag.products_Id = new SelectList(db.Products, "id", "name", productsuppliers.products_Id);
            ViewBag.suppliers_Id = new SelectList(db.Suppliers, "id", "name", productsuppliers.suppliers_Id);
            return View(productsuppliers);
        }

        //
        // POST: /ProductSppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSuppliers productsuppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsuppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.products_Id = new SelectList(db.Products, "id", "name", productsuppliers.products_Id);
            ViewBag.suppliers_Id = new SelectList(db.Suppliers, "id", "name", productsuppliers.suppliers_Id);
            return View(productsuppliers);
        }

        //
        // GET: /ProductSppliers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            if (productsuppliers == null)
            {
                return HttpNotFound();
            }
            return View(productsuppliers);
        }

        //
        // POST: /ProductSppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSuppliers productsuppliers = db.ProductSuppliers.Find(id);
            db.ProductSuppliers.Remove(productsuppliers);
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