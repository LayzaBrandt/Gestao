using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoApi.Migrations
{
    /// <inheritdoc />
    public partial class RetirarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoaoKelvin",
                table: "Pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JoaoKelvin",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
