using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoApi.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPessoaId = table.Column<int>(type: "int", nullable: true),
                    enderecoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataEmissao = table.Column<DateOnly>(type: "date", nullable: false),
                    dataEfetivaDesligamento = table.Column<DateOnly>(type: "date", nullable: true),
                    idMotivoDesligamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Pessoa_idPessoaId",
                        column: x => x.idPessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documento_idPessoaId",
                table: "Documento",
                column: "idPessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");
        }
    }
}
