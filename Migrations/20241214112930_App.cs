using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class App : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrenomEmploye",
                schema: "HR",
                table: "Employes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NomDepartement",
                schema: "HR",
                table: "Departements",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(208)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrenomEmploye",
                schema: "HR",
                table: "Employes");

            migrationBuilder.AlterColumn<string>(
                name: "NomDepartement",
                schema: "HR",
                table: "Departements",
                type: "varchar(208)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
