using ClassLibrary1;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SearchSuppliersController : Controller
    {
        private POS_DB db = new POS_DB();
        //
        // GET: /SearchSuppliers/

        public ActionResult Index()
        {
            var productSuppliers = db.ProductSuppliers.ToList();
            var model = new SearchSuppliersModels();
            model.ProductSuppliers = productSuppliers;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchSuppliersModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.ProductSuppliers = db.ProductSuppliers.ToList();
            }
            else
            {
                // fill restaurants in model
                model.ProductSuppliers = db.ProductSuppliers.Where(x => x.Products.name.Contains(search)).ToList();
            }

            // return model to the view
            return View(model);
        }
    }
}
