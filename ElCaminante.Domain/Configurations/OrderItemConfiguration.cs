using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElCaminante.Domain.Configurations
{
    public class OrderItemConfiguration
    {
        public OrderItemConfiguration(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.HasKey(oi => oi.Id);
            entityBuilder.HasIndex(oi => oi.Id);
            entityBuilder.Property(oi => oi.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(oi => oi.ProductId);
            entityBuilder.Property(oi => oi.Quantity);

            entityBuilder.Property(oi => oi.Price)
                .HasPrecision(18, 2);

            entityBuilder
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
