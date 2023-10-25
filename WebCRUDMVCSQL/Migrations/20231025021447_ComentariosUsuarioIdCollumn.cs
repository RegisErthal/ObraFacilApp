using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class ComentariosUsuarioIdCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comentarios");
        }
    }
}
