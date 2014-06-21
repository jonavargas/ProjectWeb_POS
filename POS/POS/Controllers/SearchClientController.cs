using POS.Models;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SearchClientController : Controller
    {
        private POS_DB db = new POS_DB();
        //
        // GET: /SearchClient/

        public ActionResult Index()
        {
            var client = db.Client.ToList();
            var model = new SearchClientModels();
            model.Client = client;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchClientModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.Client = db.Client.ToList();
            }
            else
            {
                model.Client = db.Client.Where(e => e.name.Contains(search)).ToList();
            }

            return View(model);
        }
    }
}