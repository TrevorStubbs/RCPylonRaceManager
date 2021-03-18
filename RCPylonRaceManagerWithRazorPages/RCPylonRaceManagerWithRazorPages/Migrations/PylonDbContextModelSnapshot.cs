﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCPylonRaceManagerWithRazorPages.Data;

namespace RCPylonRaceManagerWithRazorPages.Migrations
{
    [DbContext(typeof(PylonDbContext))]
    partial class PylonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Heat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Heats");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.HeatPilot", b =>
                {
                    b.Property<int>("SeasonPilotId")
                        .HasColumnType("int");

                    b.Property<int>("HeatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDNF")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("RaceDayPilotRaceDayId")
                        .HasColumnType("int");

                    b.Property<int?>("RaceDayPilotSeasonPilotId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("RaceTime")
                        .HasColumnType("time");

                    b.HasKey("SeasonPilotId", "HeatId");

                    b.HasIndex("HeatId");

                    b.HasIndex("RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId");

                    b.ToTable("HeatPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("RaceDays");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDayPilot", b =>
                {
                    b.Property<int>("RaceDayId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonPilotId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("FastestRaceTime")
                        .HasColumnType("time");

                    b.Property<bool>("HasPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOTS")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("LastRaceTime")
                        .HasColumnType("time");

                    b.Property<int>("RaceDayScore")
                        .HasColumnType("int");

                    b.HasKey("RaceDayId", "SeasonPilotId");

                    b.ToTable("RaceDayPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RaceDayId")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceDayId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.SeasonPilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AMANumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RaceDayPilotRaceDayId")
                        .HasColumnType("int");

                    b.Property<int?>("RaceDayPilotSeasonPilotId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("SeasonId");

                    b.HasIndex("RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId");

                    b.ToTable("SeasonPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Heat", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.Round", "Round")
                        .WithMany("Heats")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.HeatPilot", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.Heat", "Heat")
                        .WithMany("HeatPilots")
                        .HasForeignKey("HeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDayPilot", "RaceDayPilot")
                        .WithMany("HeatPilots")
                        .HasForeignKey("RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId");

                    b.Navigation("Heat");

                    b.Navigation("RaceDayPilot");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDay", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.Season", "Season")
                        .WithMany("RaceDays")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDayPilot", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDay", null)
                        .WithMany("RaceDayPilots")
                        .HasForeignKey("RaceDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Round", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDay", "RaceDay")
                        .WithMany("Rounds")
                        .HasForeignKey("RaceDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceDay");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.SeasonPilot", b =>
                {
                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.Season", "Season")
                        .WithMany("SeasonPilots")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDayPilot", "RaceDayPilot")
                        .WithMany("SeasonPilots")
                        .HasForeignKey("RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId");

                    b.Navigation("RaceDayPilot");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Heat", b =>
                {
                    b.Navigation("HeatPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDay", b =>
                {
                    b.Navigation("RaceDayPilots");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.RaceDayPilot", b =>
                {
                    b.Navigation("HeatPilots");

                    b.Navigation("SeasonPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Round", b =>
                {
                    b.Navigation("Heats");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithRazorPages.Model.Entities.Season", b =>
                {
                    b.Navigation("RaceDays");

                    b.Navigation("SeasonPilots");
                });
#pragma warning restore 612, 618
        }
    }
}
