using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElCaminante.Domain.Entities
{
    [Table("ShoppingCarts", Schema = "ELCAMINANTE")]
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<ShoppingCartItem> Items { get; set; } = new();
    }
}