using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class CategoryModel
    {
        [Required]
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public bool IsDeleted { get; set; }
    }
}