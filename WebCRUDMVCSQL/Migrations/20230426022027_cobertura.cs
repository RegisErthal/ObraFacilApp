using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class cobertura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobertura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    TamanhoCobertura = table.Column<double>(type: "float", nullable: false),
                    PossueLaje = table.Column<bool>(type: "bit", nullable: false),
                    EspessuraLaje = table.Column<double>(type: "float", nullable: false),
                    DataInicioCobertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusaoCobertura = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobertura", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobertura");
        }
    }
}
