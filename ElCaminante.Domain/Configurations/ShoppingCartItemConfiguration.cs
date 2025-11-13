using ElCaminante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElCaminante.Domain.Configurations
{
    public class ShoppingCartItemConfiguration
    {
        public ShoppingCartItemConfiguration(EntityTypeBuilder<ShoppingCartItem> entityBuilder)
        {
            entityBuilder.HasKey(sci => sci.Id);
            entityBuilder.HasIndex(sci => sci.Id);
            entityBuilder.Property(sci => sci.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(sci => sci.ProductId);
            entityBuilder.Property(sci => sci.Quantity);
            entityBuilder.Property(sci => sci.SelectedForOrder);

            entityBuilder
                .HasOne(sci => sci.Product)
                .WithMany()
                .HasForeignKey(sci => sci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
