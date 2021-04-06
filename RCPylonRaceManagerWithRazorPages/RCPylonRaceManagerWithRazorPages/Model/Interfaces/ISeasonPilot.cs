﻿using RCPylonRaceManagerWithRazorPages.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCPylonRaceManagerWithRazorPages.Model.Interfaces
{
    public interface ISeasonPilot
    {
        // Create
        Task<int> CreateASeasonPilot(SeasonPilotDTO seasonPilotDTO);
        // Get 1
        Task<SeasonPilotDTO> GetASeasonPilot(int pilotId);
        // Get all
        Task<List<SeasonPilotDTO>> GetAllSeasonsPilots();

        Task<List<SeasonPilotDTO>> GetAllSeasonsPilotsForASeason(int seasonId);
        // Update
        Task UpdateASeasonPilots(SeasonPilotDTO seasonPilotDTO);
        // Delete
        Task DeleteASeasonPilots(int pilotId);
    }
}
