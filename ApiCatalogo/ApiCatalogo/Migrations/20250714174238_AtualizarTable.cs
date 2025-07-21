using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 14, 42, 38, 219, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 14, 42, 38, 219, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 14, 42, 38, 219, DateTimeKind.Local).AddTicks(8277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 13, 49, 59, 280, DateTimeKind.Local).AddTicks(560));
        }
    }
}
