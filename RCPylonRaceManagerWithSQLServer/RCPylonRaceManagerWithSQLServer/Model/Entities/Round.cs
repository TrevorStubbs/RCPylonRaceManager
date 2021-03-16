using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class Round
    {
        public int Id { get; set; }
        public int RaceDayId { get; set; }
        public int RoundNumber { get; set; }

        // Nav Properties
        public RaceDay RaceDay { get; set; }
        public List<Heat> Heats { get; set; }
    }
}
