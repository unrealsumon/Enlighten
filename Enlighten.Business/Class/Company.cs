using Enlighten.Data;
using Enlighten.Data.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Business.Class
{
    public class Company:BaseClass
    {
        public void AddUpdateCompany(CompanyModel model)
        {
            var context = _context;
            TB_Company company = new TB_Company();

            company.CompanyName = model.CompanyName;
            company.Phone = model.Phone;
            company.Address = model.Address;
            company.Email = model.Email;
            company.HeaderInfoFirst = model.HeaderInfoFirst;
            company.HeaderInfoSecond = model.HeaderInfoSecond;
            company.HeaderInfoThird = model.HeaderInfoThird;
            company.FooterInfoFirst = model.FooterInfoFirst;
            company.FooterInfoSecond = model.FooterInfoSecond;

            context.TB_Company.Add(company);
            context.SaveChanges();
        }
    }
}