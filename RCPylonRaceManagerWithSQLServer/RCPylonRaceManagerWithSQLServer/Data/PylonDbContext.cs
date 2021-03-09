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

            modelBuilder.Entity<Season>().HasData(
                new Season
                {
                    Id = 1,
                    Year = 2021
                });
        }

        public DbSet<Season> Seasons { get; set; }


    }
}
