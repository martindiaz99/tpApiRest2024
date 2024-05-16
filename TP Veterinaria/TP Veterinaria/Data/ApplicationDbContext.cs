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
    }
}
