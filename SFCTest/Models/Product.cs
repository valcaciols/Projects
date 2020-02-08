using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SFCTest.Models
{
    public class Product
    {
        //
        [Key]
        public int IDProduct { get; set; }
        public string ProductModel { get; set; }
        public virtual List<RoutingGroup> RoutingGroup { get; set; }
    }
}