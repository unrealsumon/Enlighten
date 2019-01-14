using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Business.Class
{
    public static class LoginUser
    {
        public static string UserName { get; set; }
        public static Int32 UserID { set; get; }
        public static string UserType { set; get; }
        public static string FullName { set; get; }

        public static void SetLoginUser(string userName, Int32 userID, string fullName, string userType)
        {
            UserName = userName;
            UserID = userID;
            UserType = userType;
            FullName = fullName;
        }

        public static void Clear()
        {
            UserName = string.Empty;
            UserID = -1;
            UserType = string.Empty;
            FullName = string.Empty;
        }
    }
}