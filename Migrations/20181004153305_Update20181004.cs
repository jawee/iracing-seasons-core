using Microsoft.EntityFrameworkCore.Migrations;

namespace iRacingLeagueScoring.Migrations
{
    public partial class Update20181004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceType",
                table: "Races",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceType",
                table: "Races");
        }
    }
}
