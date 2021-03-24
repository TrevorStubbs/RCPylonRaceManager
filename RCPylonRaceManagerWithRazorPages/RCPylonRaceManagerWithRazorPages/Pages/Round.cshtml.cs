using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RCPylonRaceManagerWithRazorPages.Model.DTOs;

namespace RCPylonRaceManagerWithRazorPages.Pages
{
    public class RoundModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class RoundHeatTableSendObject
    {
        public List<HeatDTO> Heats { get; set; }
    }

    public class RoundPilotOTSSendObject
    {
        public List<HeatPilotDTO> 
    }
}
