﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCPylonRaceManagerWithSQLServer.Data;

namespace RCPylonRaceManagerWithSQLServer.Migrations
{
    [DbContext(typeof(PylonDbContext))]
    [Migration("20210309232413_reinitialEntities")]
    partial class reinitialEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.Heat", b =>
                {
                    b.Property<int>("RaceDayId")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("RaceDayId", "RoundNumber");

                    b.ToTable("Heats");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.HeatPilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDNF")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("RaceTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("HeatPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.RaceDay", b =>
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

                    b.ToTable("RaceDays");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.RaceDayPilot", b =>
                {
                    b.Property<int>("SeasonPilotId")
                        .HasColumnType("int");

                    b.Property<int>("RaceDayId")
                        .HasColumnType("int");

                    b.Property<bool>("HasPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOTS")
                        .HasColumnType("bit");

                    b.HasKey("SeasonPilotId", "RaceDayId");

                    b.ToTable("RaceDayPilots");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.Round", b =>
                {
                    b.Property<int>("RoundNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("RoundNumber");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.Season", b =>
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

            modelBuilder.Entity("RCPylonRaceManagerWithSQLServer.Model.Entities.SeasonPilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AMANumber")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SeasonPilots");
                });
#pragma warning restore 612, 618
        }
    }
}
