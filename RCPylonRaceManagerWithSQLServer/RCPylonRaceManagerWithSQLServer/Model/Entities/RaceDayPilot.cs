using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class RaceDayPilot
    {        
        public int SeasonPilotId { get; set; }
        public int RaceDayId { get; set; }
        public int RaceDayScore { get; set; }
        public bool HasPaid { get; set; }
        public bool IsOTS { get; set; }

        // Nav Properties
        public List<HeatPilot> HeatPilots { get; set; }
        public List<SeasonPilot> SeasonPilots { get; set; }
    }
}
