using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class UserController : BaseController
    {
        Users users = new Users();
        // GET: User
        public ActionResult Index()
        {
            ViewBag.IsMaster = LoginUser.IsMaster;
            return View();
        }


        



        public ActionResult AddUpdateUser(int id,UserModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }
            var result = users.AddUpdateUser(id, model);


            if (result == string.Empty)
            {
                return Json(new { message = "User Information Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult GetUserList()
        {
            Users users = new Users();
            var userList=users.GetUserList();

            return Json(userList);
        }
    }
}