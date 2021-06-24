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
    public class SeasonService : ISeason
    {
        private readonly PylonDbContext _context;

        public SeasonService(PylonDbContext context)
        {
            _context = context;
        }

        public async Task CreateASeason(SeasonDTO seasonDTO)
        {
            var seasonEntity = new Season()
            {
                Year = seasonDTO.Year
            };

            _context.Entry(seasonEntity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<SeasonDTO> GetASeason(int year)
        {
            var season = await _context.Seasons.FirstOrDefaultAsync(x => x.Year == year);

            var seasonDTO = new SeasonDTO();
            if (season != null)
            {
                seasonDTO.Id = season.Id;
                seasonDTO.Year = season.Year;
            }

            return seasonDTO;
        }

        public async Task<List<SeasonDTO>> GetAllSeasons()
        {
            var seasons = await _context.Seasons.ToListAsync();

            var seasonsDTOs = new List<SeasonDTO>();

            if (seasons.Any())
            {
                foreach (var season in seasons)
                {
                    seasonsDTOs.Add(new SeasonDTO
                    {
                        Id = season.Id,
                        Year = season.Year
                    });
                }
            }

            return seasonsDTOs;
        }

        public async Task UpdateASeason(SeasonDTO seasonDTO)
        {
            var season = await _context.Seasons.FirstOrDefaultAsync(x => x.Year == seasonDTO.Year);

            if (season != null)
            {
                season.Year = seasonDTO.Year != default ? seasonDTO.Year : season.Year;

                _context.Entry(season).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteASeason(int year)
        {
            var season = await _context.Seasons.FirstOrDefaultAsync(x => x.Year == year);

            if (season != null)
            {
                _context.Entry(season).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
