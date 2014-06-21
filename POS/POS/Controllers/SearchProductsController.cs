using ClassLibrary1;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SearchProductsController : Controller
    {

        private POS_DB db = new POS_DB();
        //
        // GET: /ProductsSearch/

        public ActionResult Index()
        {
            var warehouseProducts = db.WarehouseProducts.ToList();
            var model = new SearchProductsModels();
            model.WarehouseProducts = warehouseProducts;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchProductsModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.WarehouseProducts = db.WarehouseProducts.ToList();
            }
            else
            {
                model.WarehouseProducts = db.WarehouseProducts.Where(x => x.Products.name.Contains(search)).ToList();
            }

            return View(model);
        }
    }
}
