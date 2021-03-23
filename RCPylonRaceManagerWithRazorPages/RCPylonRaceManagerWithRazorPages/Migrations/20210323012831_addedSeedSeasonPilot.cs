using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithRazorPages.Migrations
{
    public partial class addedSeedSeasonPilot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SeasonPilots",
                columns: new[] { "Id", "AMANumber", "Email", "FirstName", "LastName", "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId", "SeasonId", "SeasonScore" },
                values: new object[] { 1, 12345, "stubbste@gmail.com", "Trevor", "Stubbs", null, null, 1, 21 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeasonPilots",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
