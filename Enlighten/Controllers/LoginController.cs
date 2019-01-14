using Enlighten.Business.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class LoginController :Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Login login = new Login();
            if (login.CheckCredentials(UserName, Password))
            {

                Session["User"] = UserName;
                Session["FullName"] = LoginUser.FullName;
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View();
            }

        }



        public ActionResult Logout()
        {
            Session.Clear();
            LoginUser.Clear();
            return RedirectToAction("Login","Login");
        }

    }
}