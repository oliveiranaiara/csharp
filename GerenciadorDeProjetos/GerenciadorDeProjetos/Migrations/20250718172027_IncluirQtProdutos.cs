using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeProjetos.Migrations
{
    /// <inheritdoc />
    public partial class IncluirQtProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeProdutos",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeProdutos",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDeProdutos",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "QuantidadeProdutos",
                table: "Categorias");
        }
    }
}
