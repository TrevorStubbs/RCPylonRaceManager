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
    public class HeatService : IHeat
    {
        private readonly PylonDbContext _context;

        public HeatService(PylonDbContext context)
        {
            _context = context;
        }

        public async Task CreateHeat(HeatDTO newHeat)
        {
            var heat = new Heat()
            {
                RoundId = newHeat.RoundId,
                HeatNumber = newHeat.HeatNumber
            };

            _context.Entry(heat).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<HeatDTO>> GetAllHeats()
        {
            var heats = await _context.Heats.ToListAsync();

            var heatsList = new List<HeatDTO>();

            if (heats.Any())
            {
                foreach (var heat in heats)
                {
                    heatsList.Add(new HeatDTO()
                    {
                        RoundId = heat.RoundId,
                        HeatNumber = heat.HeatNumber
                    });
                }
            }

            return heatsList;
        }

        public async Task<List<HeatDTO>> GetAllHeatsForRound(int roundId)
        {
            var heats = await _context.Heats.Where(x => x.Id == roundId).ToListAsync();

            var heatsList = new List<HeatDTO>();

            if (heats.Any())
            {
                foreach (var heat in heats)
                {
                    heatsList.Add(new HeatDTO()
                    {
                        RoundId = heat.RoundId,
                        HeatNumber = heat.HeatNumber
                    });
                }
            }

            return heatsList;
        }

        public async Task<HeatDTO> GetAHeat(int heatId)
        {
            var heat = await _context.Heats.FirstOrDefaultAsync(x => x.Id == heatId);

            var heatDTO = new HeatDTO();
            
            if(heat != null)
            {
                heatDTO.RoundId = heat.RoundId;
                heatDTO.HeatNumber = heat.HeatNumber;
            }

            return heatDTO;
        }
        public async Task UpdateAHeat(int heatId, HeatDTO updatedHeat)
        {
            var heat = await _context.Heats.FirstOrDefaultAsync(x => x.Id == heatId);

            if (heat != null)
            {
                heat.RoundId = updatedHeat.RoundId != default ? updatedHeat.RoundId : heat.RoundId;
                heat.HeatNumber = updatedHeat.HeatNumber != default ? updatedHeat.HeatNumber : heat.HeatNumber;

                _context.Entry(heat).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAHeat(int heatId)
        {
            var heat = await _context.Heats.FindAsync(heatId);

            _context.Entry(heat).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
