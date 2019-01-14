using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class LoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }       
        public string FullName { get; set; }
        public string UserType { get; set; }
    }
}