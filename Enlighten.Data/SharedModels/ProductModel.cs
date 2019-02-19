using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class ProductModel
    {
        [Required]
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string UnitName { get; set; }
        [Required]
        public int UnitSize { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Description { get;  set;}

    }
}