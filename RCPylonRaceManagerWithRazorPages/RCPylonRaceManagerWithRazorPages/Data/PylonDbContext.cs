using Microsoft.EntityFrameworkCore;
using RCPylonRaceManagerWithRazorPages.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCPylonRaceManagerWithRazorPages.Data
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

            // This might break it.
            modelBuilder.Entity<SeasonPilot>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<Season>().HasData(
                new Season
                {
                    Id = 1,
                    Year = 2021
                });            
            modelBuilder.Entity<SeasonPilot>().HasData(
                new SeasonPilot
                {
                    Id = 1,
                    SeasonId = 1,
                    FirstName = "Trevor",
                    LastName = "Stubbs",
                    AMANumber = 12345,
                    Email = "stubbste@gmail.com",
                    SeasonScore = 21
                },
                new SeasonPilot
                {
                    Id = 2,
                    SeasonId = 1,
                    FirstName = "Roy",
                    LastName = "Stubbs",
                    AMANumber = 56789,
                    Email = "roycstubbs@gmail.com",
                    SeasonScore = 20
                });
            modelBuilder.Entity<RaceDay>().HasData(
                new RaceDay
                {
                    Id = 1,
                    SeasonId = 1,
                    Date = new DateTime(2021, 1, 1)
                },
                new RaceDay
                {
                    Id = 2,
                    SeasonId = 1,
                    Date = new DateTime(2021, 2, 1)
                });
            modelBuilder.Entity<RaceDayPilot>().HasData(
                new RaceDayPilot
                {
                    SeasonPilotId = 1,
                    RaceDayId = 1,
                    RaceDayScore = 10,
                    HasPaid = true,
                    IsOTS = false,
                    FastestRaceTime = new TimeSpan(0, 3, 22),
                    LastRaceTime = new TimeSpan(0, 3, 40)
                },
                new RaceDayPilot
                {
                    SeasonPilotId = 2,
                    RaceDayId = 1,
                    RaceDayScore = 9,
                    HasPaid = false,
                    IsOTS = false,
                    FastestRaceTime = new TimeSpan(0, 3, 20),
                    LastRaceTime = new TimeSpan(0, 3, 40)
                });
            modelBuilder.Entity<Round>().HasData(
                new Round
                {
                    Id = 1,
                    RaceDayId = 1,
                    RoundNumber = 1
                },
                new Round
                {
                    Id = 2,
                    RaceDayId = 1,
                    RoundNumber = 2
                });
            modelBuilder.Entity<Heat>().HasData(
                new Heat
                {
                    Id = 1,
                    RoundId = 1,
                    HeatNumber = 1,
                },
                new Heat
                {
                    Id = 2,
                    RoundId = 2,
                    HeatNumber = 2
                });
            modelBuilder.Entity<HeatPilot>().HasData(
                new HeatPilot
                {
                    SeasonPilotId = 1,
                    HeatId = 1,
                    Position = 1,
                    RaceTime = new TimeSpan(0, 3, 39),
                    IsDNF = false
                },
                new HeatPilot 
                {
                    SeasonPilotId = 2,
                    HeatId = 1, 
                    Position = 2,
                    RaceTime = new TimeSpan(0, 3, 40),
                    IsDNF =  false
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
