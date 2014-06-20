using ClassLibrary1;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SearchEmployeeController : Controller
    {
        private POS_DB db = new POS_DB();
        //
        // GET: /SearchEmployee/

        public ActionResult Index()
        {
            var employee = db.Employee.ToList();
            var model = new SearchEmployeeModels();
            model.Employee = employee;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchEmployeeModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.Employee = db.Employee.ToList();
            }
            else
            {
                // fill restaurants in model
                model.Employee = db.Employee.Where(e => e.name.Contains(search)).ToList();
            }

            // return model to the view
            return View(model);
        }
    }
}