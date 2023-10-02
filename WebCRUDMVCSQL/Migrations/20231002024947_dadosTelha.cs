using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObraFacilApp.Migrations
{
    /// <inheritdoc />
    public partial class dadosTelha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Cobertura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "AlturaTelha",
                table: "Cobertura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LarguraTelha",
                table: "Cobertura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "AlturaTelha",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "LarguraTelha",
                table: "Cobertura");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Cobertura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Projeto_ProjetoId",
                table: "Cobertura",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
