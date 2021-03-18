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
    public class RoundService : IRound
    {
        private readonly PylonDbContext _context;

        public RoundService(PylonDbContext context)
        {
            _context = context;
        }

        public async Task CreateRound(RoundDTO newRound)
        {
            var round = new Round()
            {
                RaceDayId = newRound.RaceDayId,
                RoundNumber = newRound.RoundNumber
            };

            _context.Entry(round).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<RoundDTO>> GetAllRounds()
        {
            var rounds = await _context.Rounds.ToListAsync();

            var roundList = new List<RoundDTO>();

            if (rounds.Any())
            {
                foreach (var round in rounds)
                {
                    roundList.Add(new RoundDTO()
                    {
                        RaceDayId = round.RaceDayId,
                        RoundNumber = round.RoundNumber
                    });
                }
            }

            return roundList;
        }

        public async Task<List<RoundDTO>> GetALLRoundsForRaceDay(int raceDayId)
        {
            var rounds = await _context.Rounds.Where(x => x.RaceDayId == raceDayId).ToListAsync();

            var roundList = new List<RoundDTO>();

            if (rounds.Any())
            {
                foreach (var round in rounds)
                {
                    roundList.Add(new RoundDTO()
                    {
                        RaceDayId = round.RaceDayId,
                        RoundNumber = round.RoundNumber
                    });
                }
            }

            return roundList;
        }

        public async Task<RoundDTO> GetARound(int roundId)
        {
            var round = await _context.Rounds.FirstOrDefaultAsync(x => x.Id == roundId);

            var roundDTO = new RoundDTO();

            if (round != null)
            {
                roundDTO.RaceDayId = round.RaceDayId;
                roundDTO.RoundNumber = round.RoundNumber;
            }

            return roundDTO;
        }

        public async Task UpdateARound(int roundId, RoundDTO roundDTO)
        {
            var round = await _context.Rounds.FirstOrDefaultAsync(x => x.Id == roundId);

            if(round != null)
            {
                round.RaceDayId = roundDTO.RaceDayId != default ? roundDTO.RaceDayId : round.RaceDayId;
                round.RoundNumber = roundDTO.RoundNumber != default ? roundDTO.RoundNumber : round.RoundNumber;
            }
        }

        public async Task DeleteARound(int roundId)
        {
            var round = await _context.Rounds.FindAsync(roundId);

            _context.Entry(round).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
