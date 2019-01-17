using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Enlighten.Controllers
{
    public class CompanyController : BaseController
    {
        Company company = new Company();
        // GET: Company
        public ActionResult Index()
        {
            ViewBag.fullname = LoginUser.FullName;
            return View();
        }

        [HttpPost]
        public ActionResult AddUpdateCompany(int id,CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message="Please Provide All The Required Information !",type="error" }) ;
            }

                      
            var result= company.AddUpdateCompany(id,model);
            

            if (result == string.Empty)
            {
                return Json(new { message = "Company Successfully Updated", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
        }

        [HttpPost]
        public ActionResult RemoveCompany(int id)
        {
            var result= company.DeleteCompany(id);
            if (result == string.Empty)
            {
                return Json(new { message = "Company Successfully Deleted", type = "success" });
            }
            else
            {
                return Json(new { message = result, type = "error" });
            }
         
        }


        [HttpPost]
        public ActionResult ActivateCompany(int id)
        {
            var msg = company.ActivateCompany(id);
            if ( msg == "")
            {
                //Session.Clear();
                //LoginUser.Clear();
                Session["CompanyName"] = LoginUser.ActiveCompanyName;
                return Json(new { message = "Company Successfully Activated! redirecting to Login...", type = "success" });
            }
            else
            {
                return Json(new { message = msg, type = "error" });
            }
        }



        [HttpPost]   
        public async Task<ActionResult> GetCompanyList()
        {
           
            var CompanyList = await company.GetCompanyList();
            var jSonData = CompanyList.Select(c => new { c.CompanyID, c.Address, c.CompanyName, c.Email, c.Phone, c.HeaderInfoFirst, c.HeaderInfoSecond, c.HeaderInfoThird, c.FooterInfoFirst, c.FooterInfoSecond }).ToList();
           
              //var list = JsonConvert.SerializeObject(jSonData);

                return  Json (new { list = CompanyList, JsonRequestBehavior = JsonRequestBehavior.AllowGet });
            
           
  
        }

    }
}