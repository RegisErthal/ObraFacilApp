using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_models : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "IdProjeto",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "IdProjeto",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "AlturaBlocoOk",
                table: "Alvenaria");

            migrationBuilder.RenameColumn(
                name: "QtdBlocosOk",
                table: "Eletrica",
                newName: "LigacaoMonofasicaOk");

            migrationBuilder.RenameColumn(
                name: "PossueLajeOK",
                table: "Cobertura",
                newName: "MetragemCubicaLageOk");

            migrationBuilder.RenameColumn(
                name: "EspessuraLajeOk",
                table: "Cobertura",
                newName: "DataConclusaoCoberturaOK");

            migrationBuilder.RenameColumn(
                name: "DataInicioFundacaoOk",
                table: "Alvenaria",
                newName: "MetrosDeParedeOK");

            migrationBuilder.RenameColumn(
                name: "ComprimentoBlocosOk",
                table: "Alvenaria",
                newName: "DataInicioalvenariaOk");

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

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId1",
                table: "Eletrica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MetragemCubicaLAge",
                table: "Cobertura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MetrosDeParede",
                table: "Alvenaria",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrica_Projeto_ProjetoId1",
                table: "Eletrica");

            migrationBuilder.DropForeignKey(
                name: "FK_Hidraulica_Projeto_ProjetoId",
                table: "Hidraulica");

            migrationBuilder.DropIndex(
                name: "IX_Eletrica_ProjetoId1",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "ProjetoId1",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "MetragemCubicaLAge",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "MetrosDeParede",
                table: "Alvenaria");

            migrationBuilder.RenameColumn(
                name: "LigacaoMonofasicaOk",
                table: "Eletrica",
                newName: "QtdBlocosOk");

            migrationBuilder.RenameColumn(
                name: "MetragemCubicaLageOk",
                table: "Cobertura",
                newName: "PossueLajeOK");

            migrationBuilder.RenameColumn(
                name: "DataConclusaoCoberturaOK",
                table: "Cobertura",
                newName: "EspessuraLajeOk");

            migrationBuilder.RenameColumn(
                name: "MetrosDeParedeOK",
                table: "Alvenaria",
                newName: "DataInicioFundacaoOk");

            migrationBuilder.RenameColumn(
                name: "DataInicioalvenariaOk",
                table: "Alvenaria",
                newName: "ComprimentoBlocosOk");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Hidraulica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdProjeto",
                table: "Hidraulica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Eletrica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdProjeto",
                table: "Eletrica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AlturaBlocoOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Eletrica_ProjetoId",
                table: "Eletrica",
                column: "ProjetoId");

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
    }
}
