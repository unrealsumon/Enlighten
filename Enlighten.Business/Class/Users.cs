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
    public class Users:BaseClass
    {
        public string AddUpdateUser(int id, UserModel model)
        {
            var context = _context;
            TB_Company company;
            TB_User user;

            if (id == -1)
            {
                user = new TB_User();
                company = context.TB_Company.Where(x => x.CompanyID == LoginUser.ActiveCompanyID).FirstOrDefault();
                user.TB_Company.Add(company);
            }
            else
            {
                user = context.TB_User.Where(x => x.UserID== id).FirstOrDefault();
            }
            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.Password = model.Password;
            user.ActiveCompanyID = LoginUser.ActiveCompanyID;
            user.UserType = "2";
            user.IsMaster = false;
            user.MasterUserID = LoginUser.UserID;
 

            try
            {
                if (id == -1)
                {
                    context.TB_User.Add(user);
                }
                context.SaveChanges();

                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public object GetUserList()
        {
            var context = _context;



            var userList = context.TB_User.Join
                                (context.TB_Company,
                                 u => u.ActiveCompanyID,
                                 c => c.CompanyID,
                                 (u, c) => new
                                 {
                                     u.UserID,
                                     u.UserName,
                                     u.MasterUserID,
                                     u.FullName,
                                     u.ActiveCompanyID,
                                     c.CompanyID,
                                     c.CompanyName,
                                     u.IsMaster

                                 }).Where(uc => uc.MasterUserID == LoginUser.UserID).ToList();


            var list = userList.ToList();
            return list;
        }
    }
}