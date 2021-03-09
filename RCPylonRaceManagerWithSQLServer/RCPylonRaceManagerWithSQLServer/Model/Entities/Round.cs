using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class Round
    {
        [Key]
        public int RoundNumber { get; set; }

        // Nav Properties
        // public RaceDay RaceDay { get; set; }
    }
}
