using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RCPylonRaceManagerWithSQLServer.Data;
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
        }
    }
}
