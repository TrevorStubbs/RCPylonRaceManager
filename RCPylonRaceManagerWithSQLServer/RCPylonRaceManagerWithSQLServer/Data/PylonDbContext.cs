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

            modelBuilder.Entity<RaceDayPilot>().HasKey(x => new { x.RaceDayId, x.SeasonPilotId });
            modelBuilder.Entity<HeatPilot>().HasKey(x => new { x.SeasonPilotId, x.HeatId });

            modelBuilder.Entity<Season>().HasData(
                new Season
                {
                    Id = 1,
                    Year = 2021
                });

            //modelBuilder.Entity<SeasonPilot>().HasData(
            //    new SeasonPilot
            //    {
            //        Id = 1,
            //        SeasonId = 1,
            //        FirstName = "Trevor",
            //        LastName = "Stubbs",
            //        AMANumber = 12345,
            //        Email = "stubbste@gmail.com",
            //        SeasonScore = 0
            //    });
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
