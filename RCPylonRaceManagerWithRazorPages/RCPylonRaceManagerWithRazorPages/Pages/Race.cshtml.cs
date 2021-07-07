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
    public class RaceModel : PageModel
    {
        public RacePilotTableSendObject PilotTable { get; private set; }
        public RaceRoundSendObject RoundTable { get; private set; }
        public string RaceDate { get; private set; }

        private readonly IRound _round;
        private readonly IRaceDay _raceDay;
        private readonly IRaceDayPilot _pilots;
        private readonly ISeasonPilot _seasonPilot;

        public RaceModel(IRound round, IRaceDay raceDay, IRaceDayPilot pilots, ISeasonPilot seasonPilot)
        {
            _round = round;
            _raceDay = raceDay;
            _pilots = pilots;
            _seasonPilot = seasonPilot;
        }

        public async Task OnGet(int raceId)
        {
            var raceDay = await _raceDay.GetARaceDay(raceId);

            RaceDate = raceDay.Date.ToString("d");

            PilotTable = new RacePilotTableSendObject
            {
                Pilots = await _pilots.GetAllRaceDayPilotsForARaceDay(raceId),
                SeasonPilots = await _seasonPilot.GetAllSeasonsPilotsForASeason(raceDay.SeasonId)
            };

            RoundTable = new RaceRoundSendObject
            {
                Rounds = await _round.GetAllRoundsForRaceDay(raceId)
            };
        }

        public async Task OnPostNewRound()
        {

        }
    }

    public class RacePilotTableSendObject
    {
        public List<RaceDayPilotDTO> Pilots { get; set; }
        public List<SeasonPilotDTO> SeasonPilots { get; set; }
    }

    public class RaceRoundSendObject
    {
        public List<RoundDTO> Rounds { get; set; }
    }
}
