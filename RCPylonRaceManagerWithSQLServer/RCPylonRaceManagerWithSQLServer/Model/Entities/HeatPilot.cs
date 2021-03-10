using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class HeatPilot
    {        
        public int SeasonPilotId { get; set; }
        public int HeatId { get; set; }
        public int Position { get; set; }
        public TimeSpan RaceTime { get; set; }
        public bool IsDNF { get; set; }

        // Nav Properties
        public RaceDayPilot RaceDayPilot { get; set; }
        public Heat Heat { get; set; }
    }
}
