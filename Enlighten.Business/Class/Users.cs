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
        public string UpdateUser(int id, UserModel model)
        {
            var context = _context;
        
            TB_User user;     
                  
            user = context.TB_User.Where(x => x.UserID== id).FirstOrDefault();
            if (user.UserID == LoginUser.MasterUserID)
                user.IsMaster = true;
            else
            {
                user.IsMaster = model.IsMaster;
            }

            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.Password = model.Password;
            //user.ActiveCompanyID = LoginUser.ActiveCompanyID;
            user.UserType = "2";
          
            //user.MasterUserID = LoginUser.UserID;
 

            try
            {
                 
                context.SaveChanges();

                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string AddUser( UserModel model)
        {
            var context = _context;
            TB_Company company;
            TB_User user;

           
                user = new TB_User();
                company = context.TB_Company.Where(x => x.CompanyID == LoginUser.ActiveCompanyID).FirstOrDefault();
                user.TB_Company.Add(company);
          
            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.Password = model.Password;
            user.ActiveCompanyID = LoginUser.ActiveCompanyID;
            user.UserType = "2";
            user.IsMaster = model.IsMaster;
            user.MasterUserID = LoginUser.MasterUserID;


            try
            {
                context.TB_User.Add(user);                
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

            if (LoginUser.IsMaster) // when login user is master, able to see the list of all users of the selected company
            {
                var companyList =
                                  from u in context.TB_User.Where(x => x.ActiveCompanyID == LoginUser.ActiveCompanyID)

                                  select new
                                  {


                                      u.UserName,
                                      u.FullName,
                                      u.Password,
                                      u.UserType,
                                      u.MasterUserID,
                                      u.ActiveCompanyID,
                                      u.IsMaster,
                                      u.UserID
                                  };

                return companyList.ToList();
            }

            else // if login user is not master
            {
                var companyList =
                                   from u in context.TB_User.Where(x => x.UserID == LoginUser.UserID)

                                   select new
                                   {


                                       u.UserName,
                                       u.FullName,
                                       u.Password,
                                       u.UserType,
                                       u.MasterUserID,
                                       u.ActiveCompanyID,
                                       u.IsMaster,
                                       u.UserID
                                   };
                return companyList.ToList();
            }

            //var userList = context.TB_User.Join
            //                    (context.TB_Company,
            //                     u => u.ActiveCompanyID,
            //                     c => c.CompanyID,
            //                     (u, c) => new
            //                     {
            //                         u.UserID,
            //                         u.UserName,
            //                         u.MasterUserID,
            //                         u.FullName,
            //                         u.ActiveCompanyID,
            //                         c.CompanyID,
            //                         c.CompanyName,
            //                         u.IsMaster

            //                     }).Where(uc => uc.MasterUserID == LoginUser.UserID).ToList();


            //var list = userList.ToList();
            //return list;
        }

        public  string RemoveUser(int id)
        {
            if (LoginUser.MasterUserID == id)
            {
                return "Master User Cannot be RemovedN !";
            }
            var context = _context;
            TB_User user= context.TB_User.Where(x => x.UserID == id).FirstOrDefault();

            try
            {
                context.TB_User.Remove(user);
                context.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}