using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class RaceDay
    {
        public int Id { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public DateTime Date { get; set; }

        // Nav Properties
        public Season Season { get; set; }
    }
}
