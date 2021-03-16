using Microsoft.EntityFrameworkCore;
using RCPylonRaceManagerWithSQLServer.Data;
using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using RCPylonRaceManagerWithSQLServer.Model.Entities;
using RCPylonRaceManagerWithSQLServer.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Services
{
    public class HeatPilotService : IHeatPilot
    {
        private readonly PylonDbContext _context;

        public HeatPilotService(PylonDbContext context)
        {
            _context = context;
        }

        public async Task CreateHeatPilot(HeatPilotDTO newPilot)
        {
            var pilot = new HeatPilot()
            {
                SeasonPilotId = newPilot.SeasonPilotId,
                HeatId = newPilot.HeatId,
                Position = newPilot.Position,
                RaceTime = newPilot.RaceTime,
                IsDNF = newPilot.IsDNF
            };

            _context.Entry(pilot).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HeatPilotDTO>> GetAllHeatPilots()
        {
            var pilots = await _context.HeatPilots.ToListAsync();

            var pilotList = new List<HeatPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    pilotList.Add(new HeatPilotDTO()
                    {
                        SeasonPilotId = pilot.SeasonPilotId,
                        HeatId = pilot.HeatId,
                        Position = pilot.Position,
                        RaceTime = pilot.RaceTime,
                        IsDNF = pilot.IsDNF
                    });
                }
            }

            return pilotList;
        }

        public async Task<List<HeatPilotDTO>> GetALlHeatPilotsForHeat(int heatId)
        {
            var pilots = await _context.HeatPilots.Where(x => x.HeatId == heatId).ToListAsync();

            var pilotList = new List<HeatPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    pilotList.Add(new HeatPilotDTO()
                    {
                        SeasonPilotId = pilot.SeasonPilotId,
                        HeatId = pilot.HeatId,
                        Position = pilot.Position,
                        RaceTime = pilot.RaceTime,
                        IsDNF = pilot.IsDNF
                    });
                }
            }

            return pilotList;
        }

        public async Task<HeatPilotDTO> GetHeatPilot(int seasonPilotId, int heatId)
        {
            var pilot = await _context.HeatPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == seasonPilotId && x.HeatId == heatId);

            var pilotDTO = new HeatPilotDTO();

            if (pilot != null)
            {
                pilotDTO.SeasonPilotId = pilot.SeasonPilotId;
                pilotDTO.HeatId = pilot.HeatId;
                pilotDTO.Position = pilot.Position;
                pilotDTO.RaceTime = pilot.RaceTime;
                pilotDTO.IsDNF = pilot.IsDNF;
            }

            return pilotDTO;
        }

        public async Task UpdateHeatPilot(HeatPilotDTO updatedPilot)
        {
            var pilot = await _context.HeatPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == updatedPilot.SeasonPilotId && x.HeatId == updatedPilot.HeatId);

            if (pilot != null)
            {
                pilot.SeasonPilotId = updatedPilot.SeasonPilotId != default ? updatedPilot.SeasonPilotId : pilot.SeasonPilotId;
                pilot.HeatId = updatedPilot.HeatId != default ? updatedPilot.HeatId : pilot.HeatId;
                pilot.Position = updatedPilot.Position != default ? updatedPilot.Position : pilot.Position;
                pilot.RaceTime = updatedPilot.RaceTime != default ? updatedPilot.RaceTime : pilot.RaceTime;
                pilot.IsDNF = updatedPilot.IsDNF;

                _context.Entry(pilot).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteHeatPilot(int seasonPilotId, int heatId)
        {
            var pilot = await _context.HeatPilots.FirstOrDefaultAsync(x => x.SeasonPilotId == seasonPilotId && x.HeatId == heatId);

            if (pilot != null)
            {
                _context.Entry(pilot).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
