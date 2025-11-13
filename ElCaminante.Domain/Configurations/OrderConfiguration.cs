using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElCaminante.Domain.Configurations
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(o => o.Id);
            entityBuilder.HasIndex(o => o.Id);
            entityBuilder.Property(o => o.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(o => o.UserId)
                .HasMaxLength(100);

            entityBuilder.Property(o => o.DeliveryAddress)
                .HasMaxLength(255);

            entityBuilder.Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            entityBuilder.Property(o => o.TotalFee)
                .HasPrecision(18, 2);

            entityBuilder.Property(o => o.Status)
                .HasConversion<int>();

            entityBuilder.Property(o => o.CreatedAt);

            entityBuilder
                .HasMany(o => o.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
