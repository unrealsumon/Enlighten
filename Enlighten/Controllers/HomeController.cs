using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
using Enlighten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            InventoryModel model = new InventoryModel();
            model.name = "PC";
            model.qty = 3;
            TestDB db = new TestDB();
            db.insert(model);
            return View();
        }

        

        public string test()
        {

            return "Home/Index2";
        }
    }
}