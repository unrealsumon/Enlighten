using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUpdateCompany(CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message="Please Provide the Require Information !",cls="text-danger" }) ;
            }
            Company aCompany = new Company();
            aCompany.AddUpdateCompany(model);


            return Json(new { message = "Data Successfully Inserted", cls = "text-success" });
        }

    }
}