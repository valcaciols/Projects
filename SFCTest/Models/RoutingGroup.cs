using System;
using System.ComponentModel.DataAnnotations;

namespace SFCTest.Models
{
    public class RoutingGroup
    {
        [Key]
        public int IDRoutingStation { get; set; }
        public int IDProduct { get; set; }
        public int StationGroup { get; set; }
        public int PassGroup { get; set; }
        public int FailGroup { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual Product Product { get; set; }
    }
}