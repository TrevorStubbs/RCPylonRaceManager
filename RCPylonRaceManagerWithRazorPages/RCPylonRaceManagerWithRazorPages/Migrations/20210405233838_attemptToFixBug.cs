using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithRazorPages.Migrations
{
    public partial class attemptToFixBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Heats",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoundId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Heats",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoundId",
                value: 2);
        }
    }
}
