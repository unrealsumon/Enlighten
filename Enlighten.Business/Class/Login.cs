using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Business.Class
{
    public class Login:BaseClass
    {

        public bool CheckCredentials(string UserName, string Password)
        {
            var context = _context;
            var user = context.TB_User.Where(x => x.UserName == UserName && x.Password == Password)
                .Select(x => new
                {
                    x.UserName,
                    x.FullName,
                    x.UserID,
                    x.UserType,
                    x.ActiveCompanyID


                }).FirstOrDefault();

            if (user != null)
            {
                Company company = new Company();
                string ActiveCompanyName = company.GetCompanyNameByID(user.ActiveCompanyID);
                LoginUser.SetLoginUser(user.UserName, user.UserID, user.FullName, user.UserType,user.ActiveCompanyID,ActiveCompanyName);
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}