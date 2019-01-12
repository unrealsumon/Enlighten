using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class CompanyModel
    {
        [Required]
        public string CompanyName { get; set; }
        public string HeaderInfoFirst { get; set; }
        public string HeaderInfoSecond { get; set; }
        public string HeaderInfoThird { get; set; }
        public string FooterInfoFirst { get; set; }
        public string FooterInfoSecond { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}