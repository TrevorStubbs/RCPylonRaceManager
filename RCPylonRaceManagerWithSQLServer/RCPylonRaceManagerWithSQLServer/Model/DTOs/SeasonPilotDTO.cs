using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Model.DTOs
{
    public class SeasonPilotDTO
    {
        public int SeasonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AMANumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int SeasonScore { get; set; }
    }
}
