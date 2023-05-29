using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoFundacaoProjetos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdProjeto",
                table: "Fundacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Fundacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fundacao_ProjetoId",
                table: "Fundacao",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fundacao_Projeto_ProjetoId",
                table: "Fundacao");

            migrationBuilder.DropIndex(
                name: "IX_Fundacao_ProjetoId",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Fundacao");

            migrationBuilder.AlterColumn<int>(
                name: "IdProjeto",
                table: "Fundacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
