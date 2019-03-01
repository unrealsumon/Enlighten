using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enlighten.Data.SharedModels;
using Enlighten.Data;

namespace Enlighten.Business.Class
{
    public class Godown : BaseClass
    {
        public object GetGodownList()
        {
            var context = _context;
            var GodownList = context.TB_Godown.Where(x => x.CompanyID == LoginUser.ActiveCompanyID)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.IsDeleted,
                    x.GodownID
                }).OrderBy(y=>y.Name).ToList();
            var list = GodownList;
            return list;
        }

        public string AddUpdateGodown(int id, GodownModel model)
        {
            var context = _context;
            TB_Godown godown;


            if (id == -1)
            {
                godown = new TB_Godown();
            }
            else
            {
               godown = context.TB_Godown.Where(x => x.GodownID == id).FirstOrDefault();
            }

            godown.Name = model.Name;
            godown.Description = model.Description;
            godown.IsDeleted = false;


            if (LoginUser.ActiveCompanyID != null)
            {
                godown.CompanyID = (int)LoginUser.ActiveCompanyID;
            }



            try
            {
                if (id == -1)
                {
                    context.TB_Godown.Add(godown);
                }

                context.SaveChanges();
                Dispose();
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        public string RemoveGodown(int id)
        {
            var context = _context;
            TB_Godown gdn;
            gdn = context.TB_Godown.Where(x => x.GodownID == id).FirstOrDefault();
            gdn.IsDeleted = true;
            try
            {
                context.SaveChanges();
                Dispose();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}