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
    public class HomeController : BaseController
    {
        // GET: Home
     
        public ActionResult Index()
        {
            
            return View();
        }

        

        public string test()
        {

            return "Home/Index2";
        }
    }
}