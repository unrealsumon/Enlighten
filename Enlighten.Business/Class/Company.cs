using Enlighten.Data;
using Enlighten.Data.SharedModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Enlighten.Business.Class
{
    public class Company:BaseClass
    {
        public string AddUpdateCompany(int id, CompanyModel model)
        {
            var context = _context;
            TB_Company company;

            if (id == -1)
            {
                company = new TB_Company();
            }
            else
            {
                company = context.TB_Company.Where(x=>x.CompanyID == id).FirstOrDefault();
            }
            company.CompanyName = model.CompanyName;
            company.Phone = model.Phone;
            company.Address = model.Address;
            company.Email = model.Email;
            company.HeaderInfoFirst = model.HeaderInfoFirst;
            company.HeaderInfoSecond = model.HeaderInfoSecond;
            company.HeaderInfoThird = model.HeaderInfoThird;
            company.FooterInfoFirst = model.FooterInfoFirst;
            company.FooterInfoSecond = model.FooterInfoSecond;

            try
            {
                if (id == -1)
                {
                    context.TB_Company.Add(company);
                }
                context.SaveChanges();
                return "";
            }
            catch ( Exception ex)
            {

                return ex.Message;
            }
        
          
        }


        public string DeleteCompany(int id)
        {
            var context = _context;
            TB_Company company = context.TB_Company.Where(x => x.CompanyID == id).FirstOrDefault();           

            try
            {
                context.TB_Company.Remove(company);
                context.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public async Task<List<TB_Company>> GetCompanyList()
        {
            var context = _context;
            var CompanyList = await  context.TB_Company.Select(x => x).ToListAsync();
            return  CompanyList;
        }
    }
}