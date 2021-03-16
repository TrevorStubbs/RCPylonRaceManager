﻿using RCPylonRaceManagerWithSQLServer.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithSQLServer.Model.Interfaces
{
    public interface IHeatPilot
    {
        // Create
        Task CreateHeatPilot(HeatPilotDTO newPilot);
        // GetAllHeatPilots
        Task<List<HeatPilotDTO>> GetAllHeatPilots();
        // GetAllHeatPilotsForHeat
        Task<List<HeatPilotDTO>> GetALlHeatPilotsForHeat(int heatId);
        // GetAHeatPilot
        Task<HeatPilotDTO> GetHeatPilot(int seasonPilotId, int heatId);
        // UpdateHeatPilot
        Task UpdateHeatPilot(HeatPilotDTO updatedPilot);
        // DeleteHeatPilot
        Task DeleteHeatPilot(int seasonPilotId, int heatId);
    }
}
