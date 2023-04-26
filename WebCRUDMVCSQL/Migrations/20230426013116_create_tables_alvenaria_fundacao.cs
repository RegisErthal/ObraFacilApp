using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class create_tables_alvenaria_fundacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alvenaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    QtdBlocos = table.Column<double>(type: "float", nullable: false),
                    AlturaBloco = table.Column<double>(type: "float", nullable: false),
                    ComprimentoBlocos = table.Column<double>(type: "float", nullable: false),
                    QtdPilares = table.Column<double>(type: "float", nullable: false),
                    DataInicioAlvenaria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusaoAlvenaria = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alvenaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fundacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    ComprimentoAlicerce = table.Column<double>(type: "float", nullable: false),
                    AlturaAlicerce = table.Column<double>(type: "float", nullable: false),
                    QtdBlocosAlicerce = table.Column<double>(type: "float", nullable: false),
                    AlturaPedra = table.Column<double>(type: "float", nullable: false),
                    ComprimentoPedra = table.Column<double>(type: "float", nullable: false),
                    AlturaVigaBaldrame = table.Column<double>(type: "float", nullable: false),
                    ComprimentoVigaBaldrame = table.Column<double>(type: "float", nullable: false),
                    LarguraVigaBaldrame = table.Column<double>(type: "float", nullable: false),
                    MetragemCubicaCimentoVigaBaldrama = table.Column<double>(type: "float", nullable: false),
                    QtdMicro = table.Column<double>(type: "float", nullable: false),
                    DataInicioFundacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusaoFundacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundacao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alvenaria");

            migrationBuilder.DropTable(
                name: "Fundacao");
        }
    }
}
