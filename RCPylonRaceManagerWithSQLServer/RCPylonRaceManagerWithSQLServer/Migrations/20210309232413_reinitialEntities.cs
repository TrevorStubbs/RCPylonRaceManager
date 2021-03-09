using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithSQLServer.Migrations
{
    public partial class reinitialEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceDayPilot",
                table: "RaceDayPilot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heat",
                table: "Heat");

            migrationBuilder.RenameTable(
                name: "RaceDayPilot",
                newName: "RaceDayPilots");

            migrationBuilder.RenameTable(
                name: "Heat",
                newName: "Heats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceDayPilots",
                table: "RaceDayPilots",
                columns: new[] { "SeasonPilotId", "RaceDayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heats",
                table: "Heats",
                columns: new[] { "RaceDayId", "RoundNumber" });

            migrationBuilder.CreateTable(
                name: "HeatPilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    RaceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDNF = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatPilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundNumber);
                });

            migrationBuilder.CreateTable(
                name: "SeasonPilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMANumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonPilots", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeatPilots");

            migrationBuilder.DropTable(
                name: "RaceDays");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "SeasonPilots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceDayPilots",
                table: "RaceDayPilots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heats",
                table: "Heats");

            migrationBuilder.RenameTable(
                name: "RaceDayPilots",
                newName: "RaceDayPilot");

            migrationBuilder.RenameTable(
                name: "Heats",
                newName: "Heat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceDayPilot",
                table: "RaceDayPilot",
                columns: new[] { "SeasonPilotId", "RaceDayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heat",
                table: "Heat",
                columns: new[] { "RaceDayId", "RoundNumber" });
        }
    }
}
