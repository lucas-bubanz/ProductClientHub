using Microsoft.EntityFrameworkCore;
using ProductClienteHub.API.Entities;

namespace ProductClienteHub.API.Infrastructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\adm.lucasb\\Downloads\\APIClientHub.db");                    
        }
    }
}