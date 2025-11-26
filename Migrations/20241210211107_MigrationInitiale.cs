using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "Departements",
                schema: "HR",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartement = table.Column<string>(type: "varchar(208)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                schema: "HR",
                columns: table => new
                {
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEmploye = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserImage = table.Column<string>(type: "varchar(206)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salaire = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalId = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.EmployeId);
                    table.ForeignKey(
                        name: "FK_Employes_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalSchema: "HR",
                        principalTable: "Departements",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_DepartementId",
                schema: "HR",
                table: "Employes",
                column: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Departements",
                schema: "HR");
        }
    }
}
