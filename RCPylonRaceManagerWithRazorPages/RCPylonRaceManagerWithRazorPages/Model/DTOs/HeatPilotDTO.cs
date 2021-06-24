using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithRazorPages.Model.DTOs
{
    public class HeatPilotDTO
    {
        public int SeasonPilotId { get; set; }
        public int HeatId { get; set; }
        public int Position { get; set; }
        public TimeSpan RaceTime { get; set; }
        public bool IsDNF { get; set; }
        public SeasonPilotDTO PilotInfo { get; set; }
    }
}
