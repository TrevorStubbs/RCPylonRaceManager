using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithRazorPages.Model.Interfaces
{
    public interface IRaceDay
    {
        // Create
        Task CreateARaceDay(RaceDayDTO raceDay);
        // GetAll
        Task<List<RaceDayDTO>> GetAllRaceDays();
        // GetAllForSeason
        Task<List<RaceDayDTO>> GetAllRaceDaysForASeason(int seaonsId);
        // GetADay
        Task<RaceDayDTO> GetARaceDay(int raceDayId);
        // Update
        Task UpdateARaceDay(int raceDayId, RaceDayDTO raceDay);
        // Delete
        Task DeleteATask(int raceDayId);
    }
}
