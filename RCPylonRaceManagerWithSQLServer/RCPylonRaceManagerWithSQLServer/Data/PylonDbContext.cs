using Microsoft.EntityFrameworkCore;
using RCPylonRaceManagerWithSQLServer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithSQLServer.Data
{
    public class PylonDbContext : DbContext
    {
        public PylonDbContext(DbContextOptions<PylonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Heat>().HasKey(x => new { x.RaceDayId, x.RoundNumber });
            modelBuilder.Entity<RaceDayPilot>().HasKey(x => new { x.SeasonPilotId, x.RaceDayId });

            modelBuilder.Entity<Season>().HasData(
                new Season
                {
                    Id = 1,
                    Year = 2021
                });
        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Heat> Heats { get; set; }
        public DbSet<HeatPilot> HeatPilots { get; set; }
        public DbSet<RaceDay> RaceDays { get; set; }
        public DbSet<RaceDayPilot> RaceDayPilots { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<SeasonPilot> SeasonPilots { get; set; }
    }
}
