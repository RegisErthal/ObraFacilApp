using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class retira_acente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdBlocosAlicerceÒK",
                table: "Fundacao",
                newName: "QtdBlocosAlicerceOK");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Hidraulica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Eletrica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Cobertura",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Alvenaria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hidraulica_ProjetoId",
                table: "Hidraulica",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobertura_ProjetoId",
                table: "Cobertura",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alvenaria_ProjetoId",
                table: "Alvenaria",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alvenaria_Projeto_ProjetoId",
                table: "Alvenaria",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");

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
                name: "FK_Alvenaria_Projeto_ProjetoId",
                table: "Alvenaria");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura");

            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica");

            migrationBuilder.DropIndex(
                name: "IX_Hidraulica_ProjetoId",
                table: "Hidraulica");

            migrationBuilder.DropIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropIndex(
                name: "IX_Cobertura_ProjetoId",
                table: "Cobertura");

            migrationBuilder.DropIndex(
                name: "IX_Alvenaria_ProjetoId",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Alvenaria");

            migrationBuilder.RenameColumn(
                name: "QtdBlocosAlicerceOK",
                table: "Fundacao",
                newName: "QtdBlocosAlicerceÒK");
        }
    }
}
