using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.Entities
{
    public class SeasonPilot
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AMANumber { get; set; }
        [EmailAddress]        
        public string Email { get; set; }
        public int SeasonScore { get; set; }

        // Nav Properties
        public Season Season { get; set; }
        public RaceDayPilot RaceDayPilot { get; set; }
    }
}
