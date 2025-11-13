using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElCaminante.Domain.Configurations
{
    public class ShoppingCartConfiguration
    {
        public ShoppingCartConfiguration(EntityTypeBuilder<ShoppingCart> entityBuilder)
        {
            entityBuilder.HasKey(sc => sc.Id);
            entityBuilder.HasIndex(sc => sc.Id);
            entityBuilder.Property(sc => sc.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(sc => sc.UserId)
                .HasMaxLength(100);

            entityBuilder
                .HasMany(sc => sc.Items)
                .WithOne()
                .HasForeignKey("ShoppingCartId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
