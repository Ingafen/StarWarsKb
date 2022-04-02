using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWarsKb.Back.Migrations
{
    public partial class parsemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Climate",
                table: "Planets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Diameter",
                table: "Planets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gravity",
                table: "Planets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrbitalPeriod",
                table: "Planets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Planets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RotationPeriod",
                table: "Planets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SurfaceWater",
                table: "Planets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terrain",
                table: "Planets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Climate",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Gravity",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "OrbitalPeriod",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RotationPeriod",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SurfaceWater",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Terrain",
                table: "Planets");
        }
    }
}
