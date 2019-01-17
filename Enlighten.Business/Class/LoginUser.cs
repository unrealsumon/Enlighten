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
        public static Int32? ActiveCompanyID { set; get; }
        public static string ActiveCompanyName { get; set; }
        public static Int32 MasterUserID { get; set; }
        public static bool IsMaster { get; set; }

        public static void SetLoginUser(string userName, Int32 userID, string fullName, string userType,Int32? activeCompanyID, string activeCompanyName,Int32 masterUserID, bool isMaster)
        {
            UserName = userName;
            UserID = userID;
            UserType = userType;
            FullName = fullName;
            ActiveCompanyID = activeCompanyID;
            ActiveCompanyName = activeCompanyName;
            MasterUserID = masterUserID;
            IsMaster = isMaster;
        }

        public static void Clear()
        {
            UserName = string.Empty;
            UserID = -1;
            UserType = string.Empty;
            FullName = string.Empty;
            ActiveCompanyID = null;
            ActiveCompanyName = "";
            MasterUserID = -1;
            IsMaster = false;
        }
    }
}