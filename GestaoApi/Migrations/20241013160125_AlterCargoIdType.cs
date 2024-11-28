using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterCargoIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSetoresEmpresa = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataEntrada = table.Column<DateOnly>(type: "date", nullable: true),
                    DataSaida = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDoProduto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDoProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstadoDoProdutoId = table.Column<long>(type: "bigint", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_EstadoDoProduto_IdEstadoDoProdutoId",
                        column: x => x.IdEstadoDoProdutoId,
                        principalTable: "EstadoDoProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPessoaId = table.Column<long>(type: "bigint", nullable: true),
                    enderecoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissao = table.Column<DateOnly>(type: "date", nullable: false),
                    DataEfetivaDesligamento = table.Column<DateOnly>(type: "date", nullable: true),
                    idMotivoDesligamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Pessoa_IdPessoaId",
                        column: x => x.IdPessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PessoaXCargo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdCargo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaXCargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaXCargo_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaXCargo_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecursoEmpresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProdutoId = table.Column<long>(type: "bigint", nullable: true),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursoEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecursoEmpresa_Produto_IdProdutoId",
                        column: x => x.IdProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PessoaXRecursoEmpresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecursoId = table.Column<long>(type: "bigint", nullable: true),
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaXRecursoEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaXRecursoEmpresa_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaXRecursoEmpresa_RecursoEmpresa_IdRecursoId",
                        column: x => x.IdRecursoId,
                        principalTable: "RecursoEmpresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documento_IdPessoaId",
                table: "Documento",
                column: "IdPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaXCargo_IdCargo",
                table: "PessoaXCargo",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaXCargo_IdPessoa",
                table: "PessoaXCargo",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaXRecursoEmpresa_IdPessoa",
                table: "PessoaXRecursoEmpresa",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaXRecursoEmpresa_IdRecursoId",
                table: "PessoaXRecursoEmpresa",
                column: "IdRecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdEstadoDoProdutoId",
                table: "Produto",
                column: "IdEstadoDoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecursoEmpresa_IdProdutoId",
                table: "RecursoEmpresa",
                column: "IdProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "PessoaXCargo");

            migrationBuilder.DropTable(
                name: "PessoaXRecursoEmpresa");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "RecursoEmpresa");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "EstadoDoProduto");
        }
    }
}
