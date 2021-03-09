using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithSQLServer.Migrations
{
    public partial class initialEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heat",
                columns: table => new
                {
                    RaceDayId = table.Column<int>(type: "int", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heat", x => new { x.RaceDayId, x.RoundNumber });
                });

            migrationBuilder.CreateTable(
                name: "RaceDayPilot",
                columns: table => new
                {
                    SeasonPilotId = table.Column<int>(type: "int", nullable: false),
                    RaceDayId = table.Column<int>(type: "int", nullable: false),
                    HasPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsOTS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDayPilot", x => new { x.SeasonPilotId, x.RaceDayId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heat");

            migrationBuilder.DropTable(
                name: "RaceDayPilot");
        }
    }
}
