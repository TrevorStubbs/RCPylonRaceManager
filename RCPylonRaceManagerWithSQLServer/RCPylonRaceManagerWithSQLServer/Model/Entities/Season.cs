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
        //public RaceDay RaceDay { get; set; }
        //public SeasonPilot SeasonPilot { get; set; }
    }
}
