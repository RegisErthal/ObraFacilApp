using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_Fields_boll_fundacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlturaAlicerceOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ComprimentoAlicerceOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlturaAlicerceOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "ComprimentoAlicerceOK",
                table: "Fundacao");
        }
    }
}
