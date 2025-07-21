using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AmoCSHARP.Models;

namespace AmoCSHARP.Data
{
    public class FileContext : DbContext
    {
        public FileContext (DbContextOptions<FileContext> options)
            : base(options)
        {
        }

        public DbSet<AmoCSHARP.Models.Produto> Produto { get; set; } = default!;
    }
}
