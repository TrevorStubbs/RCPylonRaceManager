using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithRazorPages.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RaceDayPilots",
                columns: new[] { "RaceDayId", "SeasonPilotId", "FastestRaceTime", "HasPaid", "IsOTS", "LastRaceTime", "RaceDayScore" },
                values: new object[] { 1, 3, new TimeSpan(0, 0, 3, 25, 0), true, true, new TimeSpan(0, 0, 3, 59, 0), 5 });

            migrationBuilder.InsertData(
                table: "SeasonPilots",
                columns: new[] { "Id", "AMANumber", "Email", "FirstName", "LastName", "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId", "SeasonId", "SeasonScore" },
                values: new object[] { 3, 102354, "daveBeardsley@gmail.com", "David", "Beardsley", null, null, 1, 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceDayPilots",
                keyColumns: new[] { "RaceDayId", "SeasonPilotId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SeasonPilots",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
