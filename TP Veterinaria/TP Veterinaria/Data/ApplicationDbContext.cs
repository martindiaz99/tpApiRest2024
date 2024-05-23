using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TP_Veterinaria.Models;

namespace TP_Veterinaria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animal { get; set; } = default!;
        public DbSet<Dueño> Dueño { get; set; } = default!;
        public DbSet<HistoriaClinica> HistoriaClinica { get; set; } = default!;
        public DbSet<Medicamento> Medicamento { get; set; } = default!;
        public DbSet<Atencion> Atencion { get; set; } = default!;
    }
}
