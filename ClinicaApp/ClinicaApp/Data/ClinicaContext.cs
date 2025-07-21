using ClinicaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {

        }

        // TODAS AS TABELAS DO BANCO DE DADOS 
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }

    }
}