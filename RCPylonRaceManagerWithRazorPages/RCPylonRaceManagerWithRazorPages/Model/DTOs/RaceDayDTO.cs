using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithRazorPages.Model.DTOs
{
    public class RaceDayDTO
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public DateTime Date { get; set; }
    }
}
