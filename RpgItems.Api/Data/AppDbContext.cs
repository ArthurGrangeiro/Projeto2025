using Microsoft.EntityFrameworkCore;
using RpgItems.Core.Models;

namespace RpgItems.Api.Data   // <<< ATENÇÃO: 'Items' com M, não 'Itens'
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}
