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
    public class SeasonPilotService : ISeasonPilot
    {
        private readonly PylonDbContext _context;
        public SeasonPilotService(PylonDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateASeasonPilot(SeasonPilotDTO seasonPilotDTO)
        {
            var seasonPilot = new SeasonPilot()
            {
                SeasonId = seasonPilotDTO.SeasonId,
                FirstName = seasonPilotDTO.FirstName,
                LastName = seasonPilotDTO.LastName,
                AMANumber = seasonPilotDTO.AMANumber,
                Email = seasonPilotDTO.Email,
                SeasonScore = seasonPilotDTO.SeasonScore != default ? seasonPilotDTO.SeasonScore : 0
            };

            _context.Entry(seasonPilot).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // Get 1
        public async Task<SeasonPilotDTO> GetASeasonPilot(int pilotId)
        {
            var seasonPilot = await _context.SeasonPilots.FirstOrDefaultAsync(x => x.Id == pilotId);

            var seasonPilotDTO = new SeasonPilotDTO();
            if (seasonPilot != null)
            {
                seasonPilotDTO.SeasonId = seasonPilot.Id;
                seasonPilotDTO.FirstName = seasonPilot.FirstName;
                seasonPilotDTO.LastName = seasonPilot.LastName;
                seasonPilotDTO.AMANumber = seasonPilot.AMANumber;
                seasonPilotDTO.Email = seasonPilot.Email;
                seasonPilotDTO.SeasonScore = seasonPilot.SeasonScore;
            };

            return seasonPilotDTO;
        }

        // Get all
        public async Task<List<SeasonPilotDTO>> GetAllSeasonsPilots()
        {
            var pilots = await _context.SeasonPilots.ToListAsync();

            var seasonPilotsDTOs = new List<SeasonPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    seasonPilotsDTOs.Add(new SeasonPilotDTO
                    {
                        SeasonId = pilot.Id,
                        FirstName = pilot.FirstName,
                        LastName = pilot.LastName,
                        AMANumber = pilot.AMANumber,
                        Email = pilot.Email,
                        SeasonScore = pilot.SeasonScore
                    });
                }
            }

            return seasonPilotsDTOs;
        }

        public async Task<List<SeasonPilotDTO>> GetAllSeasonsPilotsForASeason(int seasonId)
        {
            var pilots = await _context.SeasonPilots.Where(x => x.SeasonId == seasonId).ToListAsync();

            var seasonPilotsDTOs = new List<SeasonPilotDTO>();

            if (pilots.Any())
            {
                foreach (var pilot in pilots)
                {
                    seasonPilotsDTOs.Add(new SeasonPilotDTO
                    {
                        SeasonId = pilot.Id,
                        FirstName = pilot.FirstName,
                        LastName = pilot.LastName,
                        AMANumber = pilot.AMANumber,
                        Email = pilot.Email,
                        SeasonScore = pilot.SeasonScore
                    });
                }
            }

            return seasonPilotsDTOs;
        }

        // Update
        public async Task UpdateASeasonPilots(SeasonPilotDTO seasonPilotDTO)
        {
            var pilot = await _context.SeasonPilots.FirstOrDefaultAsync(x => x.Email == seasonPilotDTO.Email);

            if(pilot != null)
            {
                pilot.FirstName = !String.IsNullOrEmpty(seasonPilotDTO.FirstName) ? seasonPilotDTO.FirstName : pilot.FirstName;
                pilot.LastName = !String.IsNullOrEmpty(seasonPilotDTO.LastName) ? seasonPilotDTO.LastName : pilot.LastName;
                pilot.AMANumber = seasonPilotDTO.AMANumber != default ? seasonPilotDTO.AMANumber : pilot.AMANumber;
                pilot.Email = !String.IsNullOrEmpty(seasonPilotDTO.Email) ? seasonPilotDTO.Email : pilot.Email;
                pilot.SeasonScore = seasonPilotDTO.SeasonScore != default ? seasonPilotDTO.SeasonScore : pilot.SeasonScore;

                _context.Entry(pilot).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        // Delete
        public async Task DeleteASeasonPilots(int pilotId)
        {
            var pilot = await _context.SeasonPilots.FirstOrDefaultAsync(x => x.Id == pilotId);

            if(pilot != null)
            {
                _context.Entry(pilot).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
