using JefflixMVC.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace JefflixMVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}
