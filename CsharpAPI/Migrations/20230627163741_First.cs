using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsharpAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localites",
                columns: table => new
                {
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localites", x => x.IdLocalite);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    IdPersonnes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLocalite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.IdPersonnes);
                    table.ForeignKey(
                        name: "FK_Personnes_Localites_IdLocalite",
                        column: x => x.IdLocalite,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { 1, "Paris" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { 2, "Lyon" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { 3, "Marseille" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonnes", "IdLocalite", "Nom" },
                values: new object[] { 1, 1, "Alice" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonnes", "IdLocalite", "Nom" },
                values: new object[] { 2, 2, "Bob" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonnes", "IdLocalite", "Nom" },
                values: new object[] { 3, 3, "Charlie" });

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_IdLocalite",
                table: "Personnes",
                column: "IdLocalite");
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
