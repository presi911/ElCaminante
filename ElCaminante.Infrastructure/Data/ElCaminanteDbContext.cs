using ElCaminante.Domain.Configurations;
using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElCaminante.Infrastructure.Data
{
    public class ElCaminanteDbContext : DbContext
    {
        public ElCaminanteDbContext(DbContextOptions<ElCaminanteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new OrderConfiguration(modelBuilder.Entity<Order>());
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new OrderItemConfiguration(modelBuilder.Entity<OrderItem>());
            new ShoppingCartConfiguration(modelBuilder.Entity<ShoppingCart>());
            new ShoppingCartItemConfiguration(modelBuilder.Entity<ShoppingCartItem>());
        }

        //dotnet ef migrations add InitialMigrationOracle --project .\ElCaminante.Infrastructure --startup-project .\ElCaminante.Api --output-dir Data\Migrations
        //dotnet ef database update --project .\ElCaminante.Infrastructure --startup-project .\ElCaminante.Api
    }
}