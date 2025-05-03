using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3___API.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.PersonId, x.InterestId });
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

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Name" },
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
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna Andersson", "0701234567" },
                    { 2, "Bertil Berg", "0739876543" },
                    { 3, "Cecilia Carlsson", "0761122334" },
                    { 4, "David Dahl", "0709876543" },
                    { 5, "Eva Eriksson", "0734567890" },
                    { 6, "Fredrik Frisk", "0765432109" },
                    { 7, "Gina Gustavsson", "0701234567" },
                    { 8, "Henrik Hansson", "0739876543" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://www.fotbollskanalen.se/" },
                    { 2, 2, 1, "https://open.spotify.com/" },
                    { 3, 3, 2, "https://csharpskolan.se/borja-har/" },
                    { 4, 4, 2, "https://www.trivago.se/" },
                    { 5, 5, 3, "https://www.kitchenlab.se/k/matlagning/" },
                    { 6, 6, 3, "https://www.gotaplatsensfoto.se/" },
                    { 7, 2, 4, "https://tidal.com/" },
                    { 8, 7, 4, "https://www.actic.se/" },
                    { 9, 8, 5, "https://litteraturbanken.se/" },
                    { 10, 9, 5, "https://www.netflix.com/se/" },
                    { 11, 10, 6, "https://store.steampowered.com/" },
                    { 12, 11, 6, "https://konst.se" },
                    { 13, 12, 7, "https://www.sverigesnatur.org/" },
                    { 14, 1, 7, "https://allsvenskan.se/" },
                    { 15, 3, 8, "https://www.javascript.com/" },
                    { 16, 5, 8, "https://www.gordonramsay.com/" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 2, 4 },
                    { 7, 4 },
                    { 8, 5 },
                    { 9, 5 },
                    { 10, 6 },
                    { 11, 6 },
                    { 1, 7 },
                    { 12, 7 },
                    { 3, 8 },
                    { 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");
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
