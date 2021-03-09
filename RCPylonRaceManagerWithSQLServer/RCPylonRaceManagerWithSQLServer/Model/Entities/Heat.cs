using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class Heat
    {
        public int RaceDayId { get; set; }
        public int RoundNumber { get; set; }

        // Nav Properties
        // public Round Round { get; set; }
        // public HeatPilot HeatPilot { get; set; }
    }
}
