﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.DTOs
{
    public class HeatPilotDTO
    {
        public int SeasonPilotId { get; set; }
        public int HeatId { get; set; }
        public int Position { get; set; }
        public TimeSpan RaceTime { get; set; }
        public bool IsDNF { get; set; }
    }
}
