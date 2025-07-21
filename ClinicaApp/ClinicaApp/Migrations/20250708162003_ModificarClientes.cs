using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApp.Migrations
{
    /// <inheritdoc />
    public partial class ModificarClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Clientes",
                newName: "Dtnasc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dtnasc",
                table: "Clientes",
                newName: "DataNascimento");
        }
    }
}
