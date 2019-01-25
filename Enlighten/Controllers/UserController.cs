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


        



        public ActionResult UpdateUser(int id,UserModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }
            if (id == -1)
            {
                return Json(new { message = "Please Select an User First !", type = "error" });
            }

            var result = users.UpdateUser(id, model);

            if (result == string.Empty)
            {
                return Json(new { message = "User Information Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }


        public ActionResult AddUser( UserModel model)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }
            var result = users.AddUser(model);


            if (result == string.Empty)
            {
                return Json(new { message = "New User Successfully Added !", type = "success" });
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

            return Json(new { list = userList, IsMaster = LoginUser.IsMaster, JsonRequestBehavior = JsonRequestBehavior.AllowGet });

        }


        [HttpPost]
        public ActionResult RemoveUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message = "User Id Undefined !", type = "error" });
            }
            Users user = new Users();
            var result = user.RemoveUser(id);
            if (result == string.Empty)
            {
                return Json(new { message = "User Successfully Deleted", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }

        }
    }
}