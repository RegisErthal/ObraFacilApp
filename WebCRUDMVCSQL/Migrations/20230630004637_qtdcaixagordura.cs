using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class qtdcaixagordura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdCaixaGortduraOk",
                table: "Hidraulica",
                newName: "QtdCaixaGorduraOk");

            migrationBuilder.RenameColumn(
                name: "QtdCaixaGortdura",
                table: "Hidraulica",
                newName: "QtdCaixaGordura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdCaixaGorduraOk",
                table: "Hidraulica",
                newName: "QtdCaixaGortduraOk");

            migrationBuilder.RenameColumn(
                name: "QtdCaixaGordura",
                table: "Hidraulica",
                newName: "QtdCaixaGortdura");
        }
    }
}
