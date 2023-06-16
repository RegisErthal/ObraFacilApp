using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class addfieldalvenaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicioalvenariaOk",
                table: "Alvenaria",
                newName: "DataInicioAlvenariaOk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicioAlvenariaOk",
                table: "Alvenaria",
                newName: "DataInicioalvenariaOk");
        }
    }
}
