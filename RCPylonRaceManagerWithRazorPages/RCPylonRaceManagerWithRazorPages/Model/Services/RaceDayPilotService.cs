using Microsoft.EntityFrameworkCore;
using RCPylonRaceManagerWithRazorPages.Data;
using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using RCPylonRaceManagerWithRazorPages.Model.Entities;
using RCPylonRaceManagerWithRazorPages.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithRazorPages.Model.Services
{
    public class RaceDayPilotService : IRaceDayPilot
    {
        private readonly PylonDbContext _context;

        public RaceDayPilotService(PylonDbContext context)
        {
            _context = context;
        }
        public async Task CreateRaceDayPilot(RaceDayPilotDTO newPilot)
        {
            var pilot = new RaceDayPilot()
            {
                SeasonPilotId = newPilot.SeasonPilotId,
                RaceDayId = newPilot.RaceDayId,
                RaceDayScore = newPilot.RaceDayScore,
                HasPaid = newPilot.HasPaid,
                IsOTS = newPilot.IsOTS                
            };

            _context.Entry(pilot).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<RaceDayPilotDTO>> GetAllRaceDayPilots()
        {
            var pilots = await _context.RaceDayPilots.ToListAsync();

            var pilotList = new List<RaceDayPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    pilotList.Add(new RaceDayPilotDTO
                    {
                        SeasonPilotId = pilot.SeasonPilotId,
                        RaceDayId = pilot.RaceDayId,
                        RaceDayScore = pilot.RaceDayScore,
                        HasPaid = pilot.HasPaid,
                        IsOTS = pilot.IsOTS,
                        FastestRaceTime = pilot.FastestRaceTime,
                        LastRaceTime = pilot.LastRaceTime
                    });
                }
            }

            return pilotList;
        }

        public async Task<List<RaceDayPilotDTO>> GetAllRaceDayPilotsForARaceDay(int raceDayId)
        {
            var pilots = await _context.RaceDayPilots.Where(x => x.RaceDayId == raceDayId).ToListAsync();

            var pilotList = new List<RaceDayPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    pilotList.Add(new RaceDayPilotDTO
                    {
                        SeasonPilotId = pilot.SeasonPilotId,
                        RaceDayId = pilot.RaceDayId,
                        RaceDayScore = pilot.RaceDayScore,
                        HasPaid = pilot.HasPaid,
                        IsOTS = pilot.IsOTS,
                        FastestRaceTime = pilot.FastestRaceTime,
                        LastRaceTime = pilot.LastRaceTime
                    });
                }
            }

            return pilotList;
        }

        public async Task<RaceDayPilotDTO> GetARaceDayPilot(int seasonPilotId, int raceDayId)
        {
            var pilot = await _context.RaceDayPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == seasonPilotId && x.RaceDayId == raceDayId);

            var pilotDTO = new RaceDayPilotDTO();

            if(pilot != null)
            {
                pilotDTO.SeasonPilotId = pilot.SeasonPilotId;
                pilotDTO.RaceDayId = pilot.RaceDayId;
                pilotDTO.RaceDayScore = pilot.RaceDayScore;
                pilotDTO.HasPaid = pilot.HasPaid;
                pilotDTO.IsOTS = pilot.IsOTS;
                pilotDTO.FastestRaceTime = pilot.FastestRaceTime;
                pilotDTO.LastRaceTime = pilot.LastRaceTime;
            }

            return pilotDTO;
        }

        public async Task UpdateARaceDayPilot(RaceDayPilotDTO updatePilot)
        {
            var pilot = await _context.RaceDayPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == updatePilot.SeasonPilotId && x.RaceDayId == updatePilot.RaceDayId);

            if(pilot != null)
            {
                pilot.SeasonPilotId = updatePilot.SeasonPilotId != default ? updatePilot.SeasonPilotId : pilot.SeasonPilotId;
                pilot.RaceDayId = updatePilot.RaceDayId != default ? updatePilot.RaceDayId : pilot.RaceDayId;
                pilot.RaceDayScore = updatePilot.RaceDayScore != default ? updatePilot.RaceDayScore : pilot.RaceDayScore;
                pilot.HasPaid = updatePilot.HasPaid;
                pilot.IsOTS = updatePilot.IsOTS;
                pilot.FastestRaceTime = updatePilot.FastestRaceTime;
                pilot.LastRaceTime = updatePilot.LastRaceTime;
            }

            _context.Entry(pilot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteARaceDayPilot(int seasonPilotId, int raceDayId)
        {
            var pilot = await _context.RaceDayPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == seasonPilotId && x.RaceDayId == raceDayId);

            if(pilot != null)
            {
                _context.Entry(pilot).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
