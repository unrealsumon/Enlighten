using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class GodownController : BaseController
    {
        Godown godown = new Godown();
        // GET: InventorySettings
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUpdateGodown(int id, GodownModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }

  
            var result = godown.AddUpdateGodown(id, model);


            if (result == string.Empty)
            {
                return Json(new { message = "Godown Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult RemoveGodown(int id)
        {
            if (id==-1)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }


            var result = godown.RemoveGodown(id);


            if (result == string.Empty)
            {
                return Json(new { message = "Godown Successfully Removed", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult GetGodownList()
        {
          

            var GodownList = godown.GetGodownList();
            return Json(new { list = GodownList, IsMaster = LoginUser.IsMaster, JsonRequestBehavior = JsonRequestBehavior.AllowGet });
        }
    }
}