using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class add_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QtdCaixaGortdura",
                table: "Hidraulica",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "QtdCaixaGortduraOk",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "QtdRegistros",
                table: "Hidraulica",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "QtdRegistrosOk",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EspessuraLajeOK",
                table: "Cobertura",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdCaixaGortdura",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdCaixaGortduraOk",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdRegistros",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdRegistrosOk",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "EspessuraLajeOK",
                table: "Cobertura");
        }
    }
}
