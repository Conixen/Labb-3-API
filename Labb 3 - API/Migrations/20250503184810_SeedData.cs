using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3___API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntrestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    MtmInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.MtmInterestId);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MtmInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_MtmInterestId",
                        column: x => x.MtmInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "MtmInterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "IntrestName" },
                values: new object[,]
                {
                    { 1, "Spela och titta på fotboll", "Fotboll" },
                    { 2, "Spela gitarr och lyssna på musik", "Musik" },
                    { 3, "Utveckla applikationer och hemsidor", "Programmering" },
                    { 4, "Besöka nya länder och kulturer", "Resa" },
                    { 5, "Laga och njuta av god mat", "Matlagning" },
                    { 6, "Ta bilder och redigera dem", "Fotografi" },
                    { 7, "Hålla sig i form och träna", "Träning" },
                    { 8, "Läsa böcker och skriva", "Litteratur" },
                    { 9, "Titta på filmer och serier", "Film" },
                    { 10, "Spela datorspel och brädspel", "Spel" },
                    { 11, "Skapa och uppskatta konstverk", "Konst" },
                    { 12, "Vandra och njuta av naturen", "Natur" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna", "Andersson", "0701234567" },
                    { 2, "Bertil", "Berg", "0739876543" },
                    { 3, "Cecilia", "Carlsson", "0761122334" },
                    { 4, "David", "Dahl", "0709876543" },
                    { 5, "Eva", "Eriksson", "0734567890" },
                    { 6, "Fredrik", "Frisk", "0765432109" },
                    { 7, "Gina", "Gustavsson", "0701234567" },
                    { 8, "Henrik", "Hansson", "0739876543" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "MtmInterestId", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 2, 4 },
                    { 8, 7, 4 },
                    { 9, 8, 5 },
                    { 10, 9, 5 },
                    { 11, 10, 6 },
                    { 12, 11, 6 },
                    { 13, 12, 7 },
                    { 14, 1, 7 },
                    { 15, 3, 8 },
                    { 16, 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "MtmInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://www.fotbollskanalen.se/" },
                    { 2, 2, "https://open.spotify.com/" },
                    { 3, 3, "https://csharpskolan.se/borja-har/" },
                    { 4, 4, "https://www.trivago.se/" },
                    { 5, 5, "https://www.kitchenlab.se/k/matlagning/" },
                    { 6, 6, "https://www.gotaplatsensfoto.se/" },
                    { 7, 7, "https://tidal.com/" },
                    { 8, 8, "https://www.actic.se/" },
                    { 9, 9, "https://litteraturbanken.se/" },
                    { 10, 10, "https://www.netflix.com/se/" },
                    { 11, 11, "https://store.steampowered.com/" },
                    { 12, 12, "https://konst.se" },
                    { 13, 13, "https://www.sverigesnatur.org/" },
                    { 14, 14, "https://allsvenskan.se/" },
                    { 15, 15, "https://www.javascript.com/" },
                    { 16, 16, "https://www.gordonramsay.com/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_MtmInterestId",
                table: "Links",
                column: "MtmInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
