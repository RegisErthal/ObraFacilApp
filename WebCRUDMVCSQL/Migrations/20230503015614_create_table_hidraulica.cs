using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class create_table_hidraulica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QtdLampadas",
                table: "Eletrica",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Hidraulica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    QtdTorneiras = table.Column<double>(type: "float", nullable: false),
                    QtdRalos = table.Column<double>(type: "float", nullable: false),
                    DataInicioEletrica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusaoEletrica = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hidraulica", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdLampadas",
                table: "Eletrica");
        }
    }
}
