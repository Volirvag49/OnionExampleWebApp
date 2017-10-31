using System.Data.Entity;
using Domain.Model;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}

// Миграции 
// Add-Migration AppMigrations -ProjectName "Infrastructure.Data"
// Update-Database -ProjectName "Infrastructure.Data"
