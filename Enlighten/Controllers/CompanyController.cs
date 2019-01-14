using Enlighten.Business.Class;
using Enlighten.Data.SharedModels;
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
            company.DeleteCompany(id);
            return Json(new { message = "Company Successfully Deleted", type = "success" });
        }


        public async Task<ActionResult> GetCompanyList()
        {
            
            var CompanyList = await company.GetCompanyList();

            return  Json(new { list = CompanyList });
        }

    }
}