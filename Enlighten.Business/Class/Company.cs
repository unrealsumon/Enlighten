﻿using Enlighten.Data;
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
            TB_User user;

            if (id == -1)
            {
                company = new TB_Company();
                user= context.TB_User.Where(x => x.UserID == LoginUser.UserID).FirstOrDefault();
                company.TB_User.Add(user);
               
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
                user = context.TB_User.Where(x => x.UserID == LoginUser.UserID && x.ActiveCompanyID ==null).FirstOrDefault();
                if (user!= null)
                {
                    user.ActiveCompanyID = company.CompanyID;
                    context.SaveChanges();
                }
                Dispose();
                return "";
            }
            catch ( Exception ex)
            {

                return ex.Message;
            }
        
          
        }

        public string ActivateCompany(int id)
        {
            var context = _context;
            TB_User user = context.TB_User.Find(LoginUser.UserID);
            user.ActiveCompanyID = id;
            try
            {
                context.SaveChanges();
                LoginUser.ActiveCompanyID = id;
                var company = context.TB_Company.Where(x => x.CompanyID == id).FirstOrDefault();
                LoginUser.ActiveCompanyName = company.CompanyName;
               
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string DeleteCompany(int id)
        {
            if (LoginUser.ActiveCompanyID == id)
            {
                return "This is The Active Company! Please Select Another Company First as Active.";
            }
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

 
        public string GetCompanyNameByID(int? id)
        {
            var context = _context;
            var compnay = context.TB_Company.Where(x => x.CompanyID == id).FirstOrDefault();
            if (compnay != null)
            {
                return compnay.CompanyName;
            }
            return "No Active Company !";
        }

        public async Task<List<TB_Company>> GetCompanyList()
        {
            var context = _context;
            //var CompanyList = await context.TB_Company.Select(x => x).ToListAsync();
            var CompanyList = await context.TB_User.Where(u => u.UserID == LoginUser.UserID).SelectMany(c => c.TB_Company).Take(400).ToListAsync();
            var list = CompanyList.ToList();
            return  list;
        }

        public object GetCompanies()
        {
            
            var context = _context;

            if (LoginUser.IsMaster)
            {


                var companyList = from c in context.TB_Company
                                  from u in c.TB_User.Where(x => x.MasterUserID == LoginUser.MasterUserID)
                                  .Select(
                                   uc => new
                                   {
                                       c.CompanyID,
                                       c.CompanyName,
                                       c.Email,
                                       c.Phone,
                                       c.HeaderInfoFirst,
                                       c.HeaderInfoSecond,
                                       c.HeaderInfoThird,
                                       c.FooterInfoFirst,
                                       c.FooterInfoSecond,
                                       //uc.MasterUserID,
                                       //uc.ActiveCompanyID,
                                       //uc.IsMaster
                                   }).GroupBy(x => x.CompanyID)
                                  select c;
                return companyList.ToList();
            }
            else
            {
                var companyList = from c in context.TB_Company
                                  from u in c.TB_User.Where(x => x.UserID == LoginUser.UserID)
                                  .Select(
                                   g => new
                                   {
                                       c.CompanyID,
                                       c.CompanyName,
                                       c.Email,
                                       c.Phone,
                                       c.HeaderInfoFirst,
                                       c.HeaderInfoSecond,
                                       c.HeaderInfoThird,
                                       c.FooterInfoFirst,
                                       c.FooterInfoSecond,
                                       //g.MasterUserID,
                                       //g.ActiveCompanyID,
                                       //g.IsMaster
                                   }).GroupBy(x => x.CompanyID)
                                  select c;
                return companyList.ToList();
            }
        }
    }
}