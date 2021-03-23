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

        public SeasonDTO SeasonDTO { get; set; }
        public SeasonPilotDTO SeasonPilotDTO { get; set; }
        public SeasonComponentObject SeasonComponentObject { get; set; }


        public SeasonModel(ISeason season, ISeasonPilot pilot)
        {
            _season = season;
            _pilot = pilot;
        }

        public async Task OnGet(int year)
        {
            SeasonDTO = await _season.GetASeason(year);
            SeasonPilotDTO = await _pilot.GetASeasonPilot(1);
            SeasonComponentObject = new SeasonComponentObject()
            {
                SeasonPilotDTOs = await _pilot.GetAllSeasonsPilots(),
                SeasonDTO = await _season.GetASeason(year),
                SeasonPilotDTO = await _pilot.GetASeasonPilot(1)
            };
        }
    }

    public class SeasonComponentObject
    {
        public SeasonDTO SeasonDTO { get; set; }
        public SeasonPilotDTO SeasonPilotDTO { get; set; }
        public List<SeasonPilotDTO> SeasonPilotDTOs { get; set; }
    }

}
