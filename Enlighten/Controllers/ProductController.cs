using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
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

        // Get product list
        [HttpPost]
        public ActionResult GetProductList()
        {
            Product product = new Product();
            var productList = product.GetProductList();

            return Json(new { list = productList, IsMaster = LoginUser.IsMaster, JsonRequestBehavior = JsonRequestBehavior.AllowGet });

        }


        [HttpPost]
        public ActionResult GetCategoryList()
        {
            Product product = new Product();
            var categoryList = product.GetCategoryList();

            return Json(new { list = categoryList, IsMaster = LoginUser.IsMaster, JsonRequestBehavior = JsonRequestBehavior.AllowGet });

        }


        [HttpPost]
        public ActionResult AddUpdateProduct(int id, ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }

            Product product = new Product();
            var result = product.AddUpdateProduct(id, model);


            if (result == string.Empty)
            {
                return Json(new { message = "Product Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult RemoveProduct(int id)
        {
            if (id==-1)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }

            Product product = new Product();
            var result = product.RemoveProduct(id);


            if (result == string.Empty)
            {
                return Json(new { message = "Product Successfully Deleted", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult RemoveCategory(int id)
        {
            if (id == -1)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }

            Product product = new Product();
            var result = product.RemoveCategory(id);


            if (result == string.Empty)
            {
                return Json(new { message = "Category Successfully Deleted", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }


        [HttpPost]
        public ActionResult AddUpdateCategory(int id, CategoryModel model)
        {
         
            if (!ModelState.IsValid)
            {
                return Json(new { message = "Please Provide All The Required Information !", type = "error" });
            }

            Product product = new Product();
            var result = product.AddUpdateCategory(id, model);


            if (result == string.Empty)
            {
                return Json(new { message = "Cattegory Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

    }
}