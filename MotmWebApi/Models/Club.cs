﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotmWebApi.Models
{
    public class Club
    {
        public int clubId { get; set; }
        public string clubName { get; set; }
        public string clubAddress { get; set; }
        public string clubLogo { get; set; }
    }
}