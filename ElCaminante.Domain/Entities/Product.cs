using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElCaminante.Domain.Entities
{
    [Table("Products", Schema = "ELCAMINANTE")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AvailableStock { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal? Rating { get; set; } // Cambiado a nullable
        public string Material { get; set; } = string.Empty;
        public ProductType ProductType { get; set; }
    }
}
