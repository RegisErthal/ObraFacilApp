using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class projetoid_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Fundacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Fundacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
