using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StarWarsKb.Back.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    StarWarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    EpisodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.StarWarId);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    StarWarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.StarWarId);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    StarWarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CostInCredits = table.Column<long>(nullable: false),
                    Lenght = table.Column<int>(nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(nullable: true),
                    CrewCount = table.Column<int>(nullable: false),
                    PassengersCount = table.Column<int>(nullable: false),
                    CargoCapacity = table.Column<long>(nullable: false),
                    Consumables = table.Column<string>(nullable: true),
                    HyperdriveRating = table.Column<string>(nullable: true),
                    MGLT = table.Column<string>(nullable: true),
                    StarshipClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.StarWarId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    StarWarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Mass = table.Column<double>(nullable: false),
                    HairColor = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    BirthYear = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    HomeWorldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.StarWarId);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "StarWarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarshipsCharacters",
                columns: table => new
                {
                    StarshipId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipsCharacters", x => new { x.CharacterId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_StarshipsCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "StarWarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipsCharacters_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "StarWarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HomeWorldId",
                table: "Characters",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_StarshipsCharacters_StarshipId",
                table: "StarshipsCharacters",
                column: "StarshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "StarshipsCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
