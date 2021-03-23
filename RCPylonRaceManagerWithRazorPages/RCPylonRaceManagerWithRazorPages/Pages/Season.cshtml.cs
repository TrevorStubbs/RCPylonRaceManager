using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using RCPylonRaceManagerWithRazorPages.Model.Interfaces;

namespace RCPylonRaceManagerWithRazorPages.Pages
{
    public class SeasonModel : PageModel
    {
        private readonly ISeason _season;
        private readonly ISeasonPilot _pilot;

        public SeasonDTO Season { get; set; }
        public SeasonTableSendObject SendObject { get; set; }


        public SeasonModel(ISeason season, ISeasonPilot pilot)
        {
            _season = season;
            _pilot = pilot;
        }

        public async Task OnGet(int year)
        {
            Season = await _season.GetASeason(year);

            SendObject = new SeasonTableSendObject()
            {
                SeasonPilotDTOs = await _pilot.GetAllSeasonsPilots(),
            };
        }
    }

    public class SeasonTableSendObject
    {
        public List<SeasonPilotDTO> SeasonPilotDTOs { get; set; }
    }

}
