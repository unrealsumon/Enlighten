using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enlighten.Data.SharedModels
{
    public class GodownModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}