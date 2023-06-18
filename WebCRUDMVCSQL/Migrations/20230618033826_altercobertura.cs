using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class altercobertura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetragemCubicaLAge",
                table: "Cobertura",
                newName: "MetragemCubicaLage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetragemCubicaLage",
                table: "Cobertura",
                newName: "MetragemCubicaLAge");
        }
    }
}
