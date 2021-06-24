using Microsoft.AspNetCore.Mvc;
using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using RCPylonRaceManagerWithRazorPages.Model.Entities;
using RCPylonRaceManagerWithRazorPages.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithRazorPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISeason _season;
        private readonly ISeasonPilot _seasonPilot;
        private readonly IRaceDay _raceDay;

        public TestController(ISeason season, ISeasonPilot seasonPilot, IRaceDay raceDay)
        {
            _season = season;
            _seasonPilot = seasonPilot;
            _raceDay = raceDay;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeasons()
        {
            var seasons = await _season.GetAllSeasons();

            return Ok(seasons);
        }

        [HttpGet, Route("seasonPilots")]
        public async Task<IActionResult> GetSeasonPilots()
        {
            var seasonPilots = await _seasonPilot.GetAllSeasonsPilots();

            return Ok(seasonPilots);
        }

        [HttpPost, Route("seasonPilot")]
        public async Task<IActionResult> PostSeasonPilot(SeasonPilotDTO newPilot)
        {
            var pilot = new SeasonPilot()
            {
                SeasonId = 1,
                FirstName = newPilot.FirstName,
                LastName = newPilot.LastName,
                AMANumber = newPilot.AMANumber,
                Email = newPilot.Email
            };            

            var id = await _seasonPilot.CreateASeasonPilot(newPilot);

            return Ok();
        }

        [HttpPost, Route("newRace")]
        public async Task<IActionResult> PostNewRace(RaceDayDTO newRace)
        {
            var id = await _raceDay.CreateARaceDay(newRace);

            return Ok(id);
        }
    }
}
