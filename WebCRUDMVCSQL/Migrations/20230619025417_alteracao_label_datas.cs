using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class alteracao_label_datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId1",
                table: "Eletrica");

            migrationBuilder.DropIndex(
                name: "IX_Eletrica_ProjetoId1",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "ProjetoId1",
                table: "Eletrica");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId1",
                table: "Eletrica",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eletrica_ProjetoId1",
                table: "Eletrica",
                column: "ProjetoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId1",
                table: "Eletrica",
                column: "ProjetoId1",
                principalTable: "Projeto",
                principalColumn: "Id");
        }
    }
}
