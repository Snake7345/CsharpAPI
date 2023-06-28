using System;
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
                    IdLocalite = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    IdPersonne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocaliteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.IdPersonne);
                    table.ForeignKey(
                        name: "FK_Personnes_Localites_LocaliteId",
                        column: x => x.LocaliteId,
                        principalTable: "Localites",
                        principalColumn: "IdLocalite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { new Guid("04a1a972-c599-4dd6-b375-545c78b60488"), "Marseille" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { new Guid("47ce056c-bf60-4063-a6f0-cc7f3264258a"), "Lyon" });

            migrationBuilder.InsertData(
                table: "Localites",
                columns: new[] { "IdLocalite", "Nom" },
                values: new object[] { new Guid("f61c2588-7332-4d3d-933f-c5b6626cdf8f"), "Paris" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonne", "LocaliteId", "Nom" },
                values: new object[] { new Guid("4757fdf6-d856-409c-a3b7-1dda24b26f33"), new Guid("47ce056c-bf60-4063-a6f0-cc7f3264258a"), "Bob" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonne", "LocaliteId", "Nom" },
                values: new object[] { new Guid("55441b1f-8ba6-4739-af30-5dbd02b33912"), new Guid("f61c2588-7332-4d3d-933f-c5b6626cdf8f"), "Alice" });

            migrationBuilder.InsertData(
                table: "Personnes",
                columns: new[] { "IdPersonne", "LocaliteId", "Nom" },
                values: new object[] { new Guid("d82d04b9-f35a-40c8-ad71-2a7e1b3e8b70"), new Guid("04a1a972-c599-4dd6-b375-545c78b60488"), "Charlie" });

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
