using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsharpAPI.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocaliteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnes_Localites_LocaliteId",
                        column: x => x.LocaliteId,
                        principalTable: "Localites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 1, "Paris" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "Lyon" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 3, "Marseille" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "Id", "LocaliteId", "Nom" },
                values: new object[] { 1, 1, "Alice" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "Id", "LocaliteId", "Nom" },
                values: new object[] { 2, 2, "Bob" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "Id", "LocaliteId", "Nom" },
                values: new object[] { 3, 3, "Charlie" });

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_LocaliteId",
                table: "Personnes",
                column: "LocaliteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Localites");
        }
    }
}
