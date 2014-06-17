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
    public class BillDetailController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /BillDetail/

        public ActionResult Index()
        {
            var billdetail = db.BillDetail.Include(b => b.Bill).Include(b => b.Products);
            return View(billdetail.ToList());
        }

        //
        // GET: /BillDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            BillDetail billdetail = db.BillDetail.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            return View(billdetail);
        }

        //
        // GET: /BillDetail/Create

        public ActionResult Create()
        {
            ViewBag.bill_Id = new SelectList(db.Bill, "id", "paymentType");
            ViewBag.products_Id = new SelectList(db.Products, "id", "name");
            return View();
        }

        //
        // POST: /BillDetail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BillDetail billdetail)
        {
            if (ModelState.IsValid)
            {
                db.BillDetail.Add(billdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bill_Id = new SelectList(db.Bill, "id", "paymentType", billdetail.bill_Id);
            ViewBag.products_Id = new SelectList(db.Products, "id", "name", billdetail.products_Id);
            return View(billdetail);
        }

        //
        // GET: /BillDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BillDetail billdetail = db.BillDetail.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.bill_Id = new SelectList(db.Bill, "id", "paymentType", billdetail.bill_Id);
            ViewBag.products_Id = new SelectList(db.Products, "id", "name", billdetail.products_Id);
            return View(billdetail);
        }

        //
        // POST: /BillDetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BillDetail billdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bill_Id = new SelectList(db.Bill, "id", "paymentType", billdetail.bill_Id);
            ViewBag.products_Id = new SelectList(db.Products, "id", "name", billdetail.products_Id);
            return View(billdetail);
        }

        //
        // GET: /BillDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BillDetail billdetail = db.BillDetail.Find(id);
            if (billdetail == null)
            {
                return HttpNotFound();
            }
            return View(billdetail);
        }

        //
        // POST: /BillDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillDetail billdetail = db.BillDetail.Find(id);
            db.BillDetail.Remove(billdetail);
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