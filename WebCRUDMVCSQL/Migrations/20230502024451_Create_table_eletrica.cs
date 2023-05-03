using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_eletrica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eletrica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    LigacaoMonofasica = table.Column<bool>(type: "bit", nullable: false),
                    LigacaoTrifasica = table.Column<bool>(type: "bit", nullable: false),
                    QtdDisjuntores = table.Column<double>(type: "float", nullable: false),
                    QtdTomadas = table.Column<double>(type: "float", nullable: false),
                    DataInicioEletrica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusaoEletrica = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrica", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eletrica");
        }
    }
}
