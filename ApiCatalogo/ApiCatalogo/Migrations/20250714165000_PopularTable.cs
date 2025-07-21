using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "ImagemUrl", "Nome" },
                values: new object[,]
                {
                    { 1, "bebidas.jpg", "Bebidas" },
                    { 2, "lanches.jpg", "Lanches" },
                    { 3, "sobremesas.jpg", "Sobremesas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "CategoriaId", "DataCadastro", "Descricao", "Estoque", "ImagemUrl", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(547), "Refrigerante 2L", 100f, "coca.jpg", "Coca-Cola", 7.5m },
                    { 2, 2, new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(555), "Pão, carne e queijo", 50f, "xburguer.jpg", "X-Burguer", 15.0m },
                    { 3, 3, new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(560), "1L sabor napolitano", 30f, "sorvete.jpg", "Sorvete Napolitano", 20.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 3);
        }
    }
}
