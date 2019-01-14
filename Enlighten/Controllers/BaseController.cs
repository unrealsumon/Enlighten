using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        //CheckUser Logged in or not
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if(requestContext.HttpContext.Session["User"] ==null) 
            {
                Response.Redirect( "~/Login/Login");                
            }
        }

      

    }
}