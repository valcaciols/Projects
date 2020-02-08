using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFCTest.Models
{
    public class RoutingGroup
    {
        [Key]
        public int IDRoutingStation { get; set; }
        public int IDProduct { get; set; }

        [ForeignKey("Station")]
        public int IDStationGroup { get; set; }

        [ForeignKey("PassStation")]
        public int IDPassGroup { get; set; }

        [ForeignKey("FailStation")]
        public int IDFailGroup { get; set; }

        public DateTime? DateCreate { get; set; }

        public virtual Product Product { get; set; }

        public virtual StationGroup Station { get; set; }

        public virtual StationGroup PassStation { get; set; }
        
        public virtual StationGroup FailStation { get; set; }
    }
}