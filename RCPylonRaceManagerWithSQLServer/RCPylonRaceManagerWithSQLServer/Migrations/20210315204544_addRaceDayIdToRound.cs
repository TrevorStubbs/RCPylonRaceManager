using Microsoft.EntityFrameworkCore.Migrations;

namespace RCPylonRaceManagerWithSQLServer.Migrations
{
    public partial class addRaceDayIdToRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RaceDays_RaceDayId",
                table: "Rounds");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SeasonPilots",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaceDayId",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPilots_Email",
                table: "SeasonPilots",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RaceDays_RaceDayId",
                table: "Rounds",
                column: "RaceDayId",
                principalTable: "RaceDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RaceDays_RaceDayId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_SeasonPilots_Email",
                table: "SeasonPilots");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SeasonPilots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaceDayId",
                table: "Rounds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RaceDays_RaceDayId",
                table: "Rounds",
                column: "RaceDayId",
                principalTable: "RaceDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
