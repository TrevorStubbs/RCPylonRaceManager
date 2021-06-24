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
                ListOfHeats = GroupHeatsIntoGroupsOfTwo(Round.Heats)
            };

            OTSPilots = new RoundPilotOTSSendObject()
            {
                OTSPilots = await _raceDayPilot.GetAllRaceDayPilotsWhoAreOTS(Round.RaceDayId)
            };
        }

        private List<List<HeatDTO>> GroupHeatsIntoGroupsOfTwo(List<HeatDTO> heats)
        {
            var outlerList = new List<List<HeatDTO>>();

            for (int i = 0; i < heats.Count; i++)
            {
                if (i == 0)
                {
                    var innerList = new List<HeatDTO>();

                    innerList.Add(heats[i]);

                    outlerList.Add(innerList);
                }
                else if (i % 2 == 0)
                {
                    var innerList = new List<HeatDTO>();

                    innerList.Add(heats[i]);

                    outlerList.Add(innerList);
                }
                else
                {
                    outlerList[outlerList.Count - 1].Add(heats[i]);
                }

            }
            return outlerList;
        }
    }

    public class RoundHeatTableSendObject
    {
        public List<List<HeatDTO>> ListOfHeats { get; set; }
    }

    public class RoundPilotOTSSendObject
    {
        public List<RaceDayPilotDTO> OTSPilots { get; set; }
    }
}
