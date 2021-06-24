using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithRazorPages.Migrations
{
    public partial class addSeedsToAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RaceDays",
                columns: new[] { "Id", "Date", "SeasonId" },
                values: new object[] { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "RaceDays",
                columns: new[] { "Id", "Date", "SeasonId" },
                values: new object[] { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "SeasonPilots",
                columns: new[] { "Id", "AMANumber", "Email", "FirstName", "LastName", "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId", "SeasonId", "SeasonScore" },
                values: new object[] { 2, 56789, "roycstubbs@gmail.com", "Roy", "Stubbs", null, null, 1, 20 });

            migrationBuilder.InsertData(
                table: "RaceDayPilots",
                columns: new[] { "RaceDayId", "SeasonPilotId", "FastestRaceTime", "HasPaid", "IsOTS", "LastRaceTime", "RaceDayScore" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 0, 3, 22, 0), true, false, new TimeSpan(0, 0, 3, 40, 0), 10 },
                    { 1, 2, new TimeSpan(0, 0, 3, 20, 0), false, false, new TimeSpan(0, 0, 3, 40, 0), 9 }
                });

            migrationBuilder.InsertData(
                table: "Rounds",
                columns: new[] { "Id", "RaceDayId", "RoundNumber" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Heats",
                columns: new[] { "Id", "HeatNumber", "RoundId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Heats",
                columns: new[] { "Id", "HeatNumber", "RoundId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "HeatPilots",
                columns: new[] { "HeatId", "SeasonPilotId", "IsDNF", "Position", "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId", "RaceTime" },
                values: new object[] { 1, 1, false, 1, null, null, new TimeSpan(0, 0, 3, 39, 0) });

            migrationBuilder.InsertData(
                table: "HeatPilots",
                columns: new[] { "HeatId", "SeasonPilotId", "IsDNF", "Position", "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId", "RaceTime" },
                values: new object[] { 1, 2, false, 2, null, null, new TimeSpan(0, 0, 3, 40, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeatPilots",
                keyColumns: new[] { "HeatId", "SeasonPilotId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HeatPilots",
                keyColumns: new[] { "HeatId", "SeasonPilotId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Heats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RaceDayPilots",
                keyColumns: new[] { "RaceDayId", "SeasonPilotId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RaceDayPilots",
                keyColumns: new[] { "RaceDayId", "SeasonPilotId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RaceDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SeasonPilots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Heats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rounds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RaceDays",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
