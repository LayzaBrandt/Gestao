using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoApi.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_Pessoa_idPessoaId",
                table: "Documento");

            migrationBuilder.AlterColumn<int>(
                name: "idPessoaId",
                table: "Documento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_Pessoa_idPessoaId",
                table: "Documento",
                column: "idPessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_Pessoa_idPessoaId",
                table: "Documento");

            migrationBuilder.AlterColumn<int>(
                name: "idPessoaId",
                table: "Documento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_Pessoa_idPessoaId",
                table: "Documento",
                column: "idPessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }
    }
}
