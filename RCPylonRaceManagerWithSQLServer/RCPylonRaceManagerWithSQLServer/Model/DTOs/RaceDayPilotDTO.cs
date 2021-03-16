using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.DTOs
{
    public class RaceDayPilotDTO
    {
        public int SeasonPilotId { get; set; }
        public int RaceDayId { get; set; }
        public int RaceDayScore { get; set; }
        public bool HasPaid { get; set; }
        public bool IsOTS { get; set; }
        public TimeSpan FastestRaceTime { get; set; }
        public TimeSpan LastRaceTime { get; set; }
    }
}
