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
    public class RoundModel : PageModel
    {
        public RoundDTO Round { get; set; }
        public RoundHeatTableSendObject HeatTables { get; set; }
        public RoundPilotOTSSendObject OTSPilots { get; set; }

        private readonly IRound _round;
        private readonly IRaceDayPilot _raceDayPilot;

        public RoundModel(IRound round, IRaceDayPilot raceDayPilot)
        {
            _round = round;
            _raceDayPilot = raceDayPilot;
        }

        public async Task OnGet(int roundId)
        {
            Round = await _round.GetARound(roundId);

            HeatTables = new RoundHeatTableSendObject()
            {
                Heats = Round.Heats
            };

            OTSPilots = new RoundPilotOTSSendObject()
            {
                OTSPilots = await _raceDayPilot.GetAllRaceDayPilotsWhoAreOTS(Round.RaceDayId)
            };
        }
    }

    public class RoundHeatTableSendObject
    {
        public List<HeatDTO> Heats { get; set; }
    }

    public class RoundPilotOTSSendObject
    {
        public List<RaceDayPilotDTO> OTSPilots { get; set; }
    }
}
