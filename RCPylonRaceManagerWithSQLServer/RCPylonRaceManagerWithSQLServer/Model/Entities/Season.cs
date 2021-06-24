using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }

        // Nav Properties
        public List<RaceDay> RaceDays { get; set; }
        public List<SeasonPilot> SeasonPilots { get; set; }
    }
}
