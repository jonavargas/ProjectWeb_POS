using ClassLibrary1;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SearchWarehouseProductsController : Controller
    {
        private POS_DB db = new POS_DB();
        //
        // GET: /SearchWarehouse/

        public ActionResult Index()
        {
            var warehouse = db.WarehouseProducts.ToList();
            var model = new SearchWarehouseProductsModels();
            model.WarehouseProducts = warehouse;
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Index(SearchWarehouseProductsModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.WarehouseProducts = db.WarehouseProducts.ToList();
            }
            else
            {
                model.WarehouseProducts = db.WarehouseProducts.Where(e => e.Products.name.Contains(search)).ToList();
            }

            return View(model);
        }
    }
}
