using Enlighten.Business.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetProductList()
        {
            Product product = new Product();
            var productList = product.GetProductList();

            return Json(new { list = productList, IsMaster = LoginUser.IsMaster, JsonRequestBehavior = JsonRequestBehavior.AllowGet });

        }
    }
}