using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Interfaces
{
    public interface IRound
    {
        // Create
        Task CreateRound(RoundDTO newRound);
        // GetAllRounds
        Task<List<RoundDTO>> GetAllRounds();
        // GetAllRoundsForRaceDay        
        Task<List<RoundDTO>> GetALLRoundsForRaceDay(int raceDayId);
        // GetRound
        Task<RoundDTO> GetARound(int roundId);
        // Update
        Task UpdateARound(int roundId, RoundDTO roundDTO);
        // Delete
        Task DeleteARound(int roundId);
    }
}
