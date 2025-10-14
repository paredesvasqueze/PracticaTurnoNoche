using Microsoft.EntityFrameworkCore;
using SistemaColegio.Models;
using System.Collections.Generic;

namespace SistemaColegio.Data
{
    public class ColegioContext : DbContext
    {
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options)
        {
        }

        public DbSet<Matricula> Matriculas { get; set; }  // Representa la tabla Matriculas
    }
}
