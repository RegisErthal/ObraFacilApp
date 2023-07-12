using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class altera_display : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Hidraulica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Eletrica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Hidraulica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Eletrica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
