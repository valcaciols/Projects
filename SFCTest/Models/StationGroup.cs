﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SFCTest.Models
{
    public class StationGroup
    {
        [Key]
        public int IDStationGroup { get; set; }

        public string STATION_GROUP_CODE { get; set; }

        public string DESCRIPTION { get; set; }
    }
}