using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class RaceDayPilot
    {
        public int SeasonPilotId { get; set; }
        public int RaceDayId { get; set; }
        public bool HasPaid { get; set; }
        public bool IsOTS { get; set; }

        // Nav Properties
        public HeatPilot HeatPilot { get; set; }
        public SeasonPilot SeasonPilot { get; set; }
    }
}
