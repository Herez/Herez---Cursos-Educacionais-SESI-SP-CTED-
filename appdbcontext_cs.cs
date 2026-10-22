using Microsoft.EntityFrameworkCore;
using CatalogoCursosApi.Models;

namespace CatalogoCursosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; } = null!;
    }
}