using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Interfaces
{
    public interface IHeat
    {
        // CreateHeat
        Task CreateHeat(HeatDTO newHeat);
        // GetAllHeats
        Task<List<HeatDTO>> GetAllHeats();
        // GetAllHeatsForRound
        Task<List<HeatDTO>> GetAllHeatsForRound(int roundId);
        // GetAHeat
        Task<HeatDTO> GetAHeat(int heatId);
        // UpdateAHeat
        Task UpdateAHeat(int heatId, HeatDTO updatedHeat);
        // DeleteAHeat
        Task DeleteAHeat(int heatId);
    }
}
