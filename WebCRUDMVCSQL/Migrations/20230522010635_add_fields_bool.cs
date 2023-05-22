using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class add_fields_bool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicioEletrica",
                table: "Hidraulica",
                newName: "DataInicioHidraulica ");

            migrationBuilder.RenameColumn(
                name: "DataConclusaoEletrica",
                table: "Hidraulica",
                newName: "DataConclusaoHidraulica");

            migrationBuilder.AddColumn<bool>(
                name: "DataConclusaoHidraulicaOK",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataInicioHidraulicaOK",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdRalosOK",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdTorneirasOK",
                table: "Hidraulica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlturaPedraOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlturaVigaBaldrameOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ComprimentoPedraOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ComprimentoVigaBaldrameOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataConclusaoFundacaoOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataInicioFundacaoOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LarguraVigaBaldrameOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MetragemCubicaCimentoVigaBaldramaOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdBlocosAlicerceÒK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdMicroOK",
                table: "Fundacao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataConclusaoEletricaOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataInicioEletricaOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LigacaoTrifasicaOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdBlocosOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdDisjuntoresOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdLampadasOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdTomadasOk",
                table: "Eletrica",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataInicioCoberturaOK",
                table: "Cobertura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EspessuraLajeOk",
                table: "Cobertura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PossueLajeOK",
                table: "Cobertura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TamanhoCoberturaOK",
                table: "Cobertura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlturaBlocoOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ComprimentoBlocosOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataConclusaoAlvenariaOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DataInicioFundacaoOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdBlocosOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QtdPilaresOk",
                table: "Alvenaria",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusaoHidraulicaOK",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "DataInicioHidraulicaOK",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdRalosOK",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "QtdTorneirasOK",
                table: "Hidraulica");

            migrationBuilder.DropColumn(
                name: "AlturaPedraOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "AlturaVigaBaldrameOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "ComprimentoPedraOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "ComprimentoVigaBaldrameOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "DataConclusaoFundacaoOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "DataInicioFundacaoOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "LarguraVigaBaldrameOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "MetragemCubicaCimentoVigaBaldramaOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "QtdBlocosAlicerceÒK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "QtdMicroOK",
                table: "Fundacao");

            migrationBuilder.DropColumn(
                name: "DataConclusaoEletricaOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "DataInicioEletricaOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "LigacaoTrifasicaOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "QtdBlocosOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "QtdDisjuntoresOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "QtdLampadasOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "QtdTomadasOk",
                table: "Eletrica");

            migrationBuilder.DropColumn(
                name: "DataInicioCoberturaOK",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "EspessuraLajeOk",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "PossueLajeOK",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "TamanhoCoberturaOK",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "AlturaBlocoOk",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "ComprimentoBlocosOk",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "DataConclusaoAlvenariaOk",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "DataInicioFundacaoOk",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "QtdBlocosOk",
                table: "Alvenaria");

            migrationBuilder.DropColumn(
                name: "QtdPilaresOk",
                table: "Alvenaria");

            migrationBuilder.RenameColumn(
                name: "DataInicioHidraulica ",
                table: "Hidraulica",
                newName: "DataInicioEletrica");

            migrationBuilder.RenameColumn(
                name: "DataConclusaoHidraulica",
                table: "Hidraulica",
                newName: "DataConclusaoEletrica");
        }
    }
}
