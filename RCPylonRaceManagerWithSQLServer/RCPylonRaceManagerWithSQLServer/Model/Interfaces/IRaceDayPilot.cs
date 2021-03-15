using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Interfaces
{
    public interface IRaceDayPilot
    {
        // Create 
        Task CreateRaceDayPilot(RaceDayPilotDTO newPilot);
        // GetAllRaceDayPilots
        Task<List<RaceDayPilotDTO>> GetAllRaceDayPilots();
        // GetAllRaceDayPilotsForRaceDay
        Task<List<RaceDayPilotDTO>> GetAllRaceDayPilotsForARaceDay(int raceDayId);
        // GetARaceDayPilot
        Task<RaceDayPilotDTO> GetARaceDayPilot(int seasonPilotId, int raceDayId);
        // UpdateRaceDayPilot
        Task UpdateARaceDayPilot(RaceDayPilotDTO updatePilot);
        // Delete
        Task DeleteARaceDayPilot(int seasonPilotId, int raceDayId);;
    }
}
