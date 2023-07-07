using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class alteranomeccccc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cccc",
                table: "Fundacao",
                newName: "AlicerceOK");

            migrationBuilder.AlterColumn<string>(
                name: "Responsável",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlicerceOK",
                table: "Fundacao",
                newName: "cccc");

            migrationBuilder.AlterColumn<string>(
                name: "Responsável",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
