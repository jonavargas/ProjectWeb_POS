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
    public class BillController : Controller
    {
        private POS_DB db = new POS_DB();

        //
        // GET: /Bill/

        public ActionResult Index()
        {
            var bill = db.Bill.Include(b => b.Client).Include(b => b.Employee);
            return View(bill.ToList());
        }

        //
        // GET: /Bill/Details/5

        public ActionResult Details(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // GET: /Bill/Create

        public ActionResult Create()
        {
            ViewBag.client_Id = new SelectList(db.Client, "id", "name");
            ViewBag.employee_Id = new SelectList(db.Employee, "id", "name");
            return View();
        }

        //
        // POST: /Bill/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bill.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_Id = new SelectList(db.Client, "id", "name", bill.client_Id);
            ViewBag.employee_Id = new SelectList(db.Employee, "id", "name", bill.employee_Id);
            return View(bill);
        }

        //
        // GET: /Bill/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_Id = new SelectList(db.Client, "id", "name", bill.client_Id);
            ViewBag.employee_Id = new SelectList(db.Employee, "id", "name", bill.employee_Id);
            return View(bill);
        }

        //
        // POST: /Bill/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_Id = new SelectList(db.Client, "id", "name", bill.client_Id);
            ViewBag.employee_Id = new SelectList(db.Employee, "id", "name", bill.employee_Id);
            return View(bill);
        }

        //
        // GET: /Bill/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // POST: /Bill/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bill.Find(id);
            db.Bill.Remove(bill);
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