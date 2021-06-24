using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class Heat
    {
        public int Id { get; set; }

        //[ForeignKey("RoundId")]
        public int RoundId { get; set; }
        public int HeatNumber { get; set; }

        // Nav Properties
        public Round Round { get; set; }
        public List<HeatPilot> HeatPilots { get; set; }
    }
}
