using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithSQLServer.Migrations
{
    public partial class reinitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_RaceDays_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceDayPilots",
                columns: table => new
                {
                    SeasonPilotId = table.Column<int>(type: "int", nullable: false),
                    RaceDayId = table.Column<int>(type: "int", nullable: false),
                    RaceDayScore = table.Column<int>(type: "int", nullable: false),
                    HasPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsOTS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDayPilots", x => new { x.RaceDayId, x.SeasonPilotId });
                    table.ForeignKey(
                        name: "FK_RaceDayPilots_RaceDays_RaceDayId",
                        column: x => x.RaceDayId,
                        principalTable: "RaceDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceDayId = table.Column<int>(type: "int", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_RaceDays_RaceDayId",
                        column: x => x.RaceDayId,
                        principalTable: "RaceDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeasonScore = table.Column<int>(type: "int", nullable: false),
                    RaceDayPilotRaceDayId = table.Column<int>(type: "int", nullable: true),
                    RaceDayPilotSeasonPilotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonPilots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonPilots_RaceDayPilots_RaceDayPilotRaceDayId_RaceDayPilotSeasonPilotId",
                        columns: x => new { x.RaceDayPilotRaceDayId, x.RaceDayPilotSeasonPilotId },
                        principalTable: "RaceDayPilots",
                        principalColumns: new[] { "RaceDayId", "SeasonPilotId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeasonPilots_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    HeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heats_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeatPilots",
                columns: table => new
                {
                    SeasonPilotId = table.Column<int>(type: "int", nullable: false),
                    HeatId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    RaceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDNF = table.Column<bool>(type: "bit", nullable: false),
                    RaceDayPilotRaceDayId = table.Column<int>(type: "int", nullable: true),
                    RaceDayPilotSeasonPilotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatPilots", x => new { x.SeasonPilotId, x.HeatId });
                    table.ForeignKey(
                        name: "FK_HeatPilots_Heats_HeatId",
                        column: x => x.HeatId,
                        principalTable: "Heats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeatPilots_RaceDayPilots_RaceDayPilotRaceDayId_RaceDayPilotSeasonPilotId",
                        columns: x => new { x.RaceDayPilotRaceDayId, x.RaceDayPilotSeasonPilotId },
                        principalTable: "RaceDayPilots",
                        principalColumns: new[] { "RaceDayId", "SeasonPilotId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "Year" },
                values: new object[] { 1, 2021 });

            migrationBuilder.CreateIndex(
                name: "IX_HeatPilots_HeatId",
                table: "HeatPilots",
                column: "HeatId");

            migrationBuilder.CreateIndex(
                name: "IX_HeatPilots_RaceDayPilotRaceDayId_RaceDayPilotSeasonPilotId",
                table: "HeatPilots",
                columns: new[] { "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId" });

            migrationBuilder.CreateIndex(
                name: "IX_Heats_RoundId",
                table: "Heats",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDays_SeasonId",
                table: "RaceDays",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_RaceDayId",
                table: "Rounds",
                column: "RaceDayId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPilots_Email",
                table: "SeasonPilots",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPilots_RaceDayPilotRaceDayId_RaceDayPilotSeasonPilotId",
                table: "SeasonPilots",
                columns: new[] { "RaceDayPilotRaceDayId", "RaceDayPilotSeasonPilotId" });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPilots_SeasonId",
                table: "SeasonPilots",
                column: "SeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeatPilots");

            migrationBuilder.DropTable(
                name: "SeasonPilots");

            migrationBuilder.DropTable(
                name: "Heats");

            migrationBuilder.DropTable(
                name: "RaceDayPilots");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "RaceDays");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
