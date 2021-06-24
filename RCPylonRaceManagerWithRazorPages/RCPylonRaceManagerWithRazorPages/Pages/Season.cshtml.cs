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
        private readonly IRaceDay _race;

        public SeasonDTO Season { get; set; }
        public SeasonTableSendObject SendObject { get; set; }
        public SeasonRaceTableSendObject RaceSendObject { get; set; }


        public SeasonModel(ISeason season, ISeasonPilot pilot, IRaceDay race)
        {
            _season = season;
            _pilot = pilot;
            _race = race;
        }

        public async Task OnGet(int year)
        {
            Season = await _season.GetASeason(year);

            SendObject = new SeasonTableSendObject()
            {
                SeasonPilotDTOs = await _pilot.GetAllSeasonsPilotsForASeason(Season.Id),
                SeasonYear = Season.Year
            };

            RaceSendObject = new SeasonRaceTableSendObject()
            {
                RaceDayDTOs = await _race.GetAllRaceDaysForASeason(Season.Id)
            };
        }

        public async Task OnPost(SeasonPilotDTO seasonPilotDTO, int seasonYear)
        {
            var season = await _season.GetASeason(seasonYear);

            seasonPilotDTO.SeasonId = season.Id;

            var pilotId = await _pilot.CreateASeasonPilot(seasonPilotDTO);

            //return RedirectToPage("Season", season.Year);
        }

        // TODO: Need to fix the rerouting/Redirecting
        public async Task<RedirectToPageResult> OnPostNewRace(RaceDayDTO newRace, int seasonYear)
        {
            var season = await _season.GetASeason(seasonYear);

            newRace.SeasonId = season.Id;            

            var raceId = await _race.CreateARaceDay(newRace);

            // return RedirectToRoute($"../../race/{raceId}");            

            return RedirectToPage($"Race/{raceId}", raceId);

        }
    }

    public class SeasonTableSendObject
    {
        public List<SeasonPilotDTO> SeasonPilotDTOs { get; set; }
        public int SeasonYear { get; set; }
    }

    public class SeasonRaceTableSendObject
    {
        public List<RaceDayDTO> RaceDayDTOs { get; set; }
    }

}
