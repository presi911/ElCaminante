using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ElCaminante.Domain.Configurations
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.HasIndex(p => p.Id);
            entityBuilder.Property(p => p.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            entityBuilder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            entityBuilder.Property(p => p.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(255);

            entityBuilder.Property(p => p.AvailableStock)
                .IsRequired();

            entityBuilder.Property(p => p.Size)
                .IsRequired(false)
                .HasMaxLength(50);

            entityBuilder.Property(p => p.Color)
                .IsRequired(false)
                .HasMaxLength(50);

            entityBuilder.Property(p => p.Rating)
                .IsRequired(false)
                .HasPrecision(18, 2);

            entityBuilder.Property(p => p.Material)
                .IsRequired(false)
                .HasMaxLength(100);

            entityBuilder.Property(p => p.ProductType)
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
