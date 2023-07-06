using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class PrevisaoCusto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrevisaoCusto",
                table: "Hidraulica",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrevisaoCusto",
                table: "Fundacao",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrevisaoCusto",
                table: "Eletrica",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrevisaoCusto",
                table: "Cobertura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrevisaoCusto",
                table: "Alvenaria",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrevisaoCusto",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "PrevisaoCusto",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "PrevisaoCusto",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "PrevisaoCusto",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "PrevisaoCusto",
                table: "Alvenaria");
        }
    }
}
