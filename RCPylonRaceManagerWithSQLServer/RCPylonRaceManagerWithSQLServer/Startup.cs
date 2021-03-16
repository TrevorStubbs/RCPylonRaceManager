using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCPylonRaceManagerWithSQLServer.Data;
using RCPylonRaceManagerWithSQLServer.Forms;
using RCPylonRaceManagerWithSQLServer.Model.Interfaces;
using RCPylonRaceManagerWithSQLServer.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer
{
    public class Startup
    {
        public IConfiguration Config { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Config = builder.Build();
        }

        public void ConfigureServcies(IServiceCollection services)
        {
            services.AddDbContext<PylonDbContext>(options =>
            {
                options.UseSqlServer(Config.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IHeat, HeatService>();
            services.AddTransient<IHeatPilot, HeatPilotService>();
            services.AddTransient<IRaceDay, RaceDayService>();
            services.AddTransient<IRaceDayPilot, RaceDayPilotService>();
            services.AddTransient<IRound, RoundService>();
            services.AddTransient<ISeasonPilot, SeasonPilotService>();
            services.AddTransient<ISeason, SeasonService>();
            services.AddScoped<EntryForm>();

        }
    }
}
