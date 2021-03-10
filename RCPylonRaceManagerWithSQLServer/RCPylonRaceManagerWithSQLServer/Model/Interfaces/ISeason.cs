using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Interfaces
{
    public interface ISeason
    {
        // Create
        Task CreateASeason(SeasonDTO seasonDTO);
        // Get 1
        Task<SeasonDTO> GetASeason(int year);
        // Get all
        Task<List<SeasonDTO>> GetAllSeasons();
        // Update
        Task UpdateASeason(SeasonDTO seasonDTO);
        // Delete
        Task DeleteASeason(int year);
    }
}
