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
    public class RaceDayService : IRaceDay
    {
        private readonly PylonDbContext _context;

        public RaceDayService(PylonDbContext context)
        {
            _context = context;
        }

        public async Task CreateARaceDay(RaceDayDTO raceDay)
        {
            var raceDayEntity = new RaceDay()
            {
                SeasonId = raceDay.SeasonId,
                Date = raceDay.Date
            };

            _context.Entry(raceDayEntity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<RaceDayDTO>> GetAllRaceDays()
        {
            var races = await _context.RaceDays.ToListAsync();

            var racesList = new List<RaceDayDTO>();
            if (races.Any())
            {
                foreach (var race in races)
                {
                    racesList.Add(new RaceDayDTO()
                    {
                        SeasonId = race.SeasonId,
                        Date = race.Date
                    });
                }
            }

            return racesList;
        }

        public async Task<List<RaceDayDTO>> GetAllRaceDaysForASeason(int seaonsId)
        {
            var races = await _context.RaceDays.Where(x => x.SeasonId == seaonsId).ToListAsync();

            var racesList = new List<RaceDayDTO>();
            if (races.Any())
            {
                foreach (var race in races)
                {
                    racesList.Add(new RaceDayDTO()
                    {
                        SeasonId = race.SeasonId,
                        Date = race.Date
                    });
                }
            }

            return racesList;
        }

        public async Task<RaceDayDTO> GetARaceDay(int raceDayId)
        {
            var race = await _context.RaceDays.FirstOrDefaultAsync(x => x.Id == raceDayId);

            var raceDTO = new RaceDayDTO();

            if (race != null)
            {
                raceDTO.SeasonId = race.SeasonId;
                raceDTO.Date = race.Date;
            }

            return raceDTO;
        }

        public async Task UpdateARaceDay(int raceDayId, RaceDayDTO raceDay)
        {
            var race = await _context.RaceDays.FirstOrDefaultAsync(x => x.Id == raceDayId);

            if(race != null)
            {
                race.SeasonId = raceDay.SeasonId != default ? raceDay.SeasonId : race.SeasonId;
                race.Date = raceDay.Date != default ? raceDay.Date : race.Date;
            }
        }

        public async Task DeleteATask(int raceDayId)
        {
            var race = await _context.RaceDays.FindAsync(raceDayId);

            if(race != null)
            {
                _context.Entry(race).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
