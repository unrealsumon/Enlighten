﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class UserModel
    {
       [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
       
        public string UserType { get; set; }
    
        public Nullable<int> ActiveCompanyID { get; set; }
    }
}