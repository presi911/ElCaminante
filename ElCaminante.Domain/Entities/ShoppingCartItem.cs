using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElCaminante.Domain.Entities
{
    [Table("ShoppingCartItems", Schema = "ELCAMINANTE")]
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public int SelectedForOrder { get; set; } // 0 = No seleccionado, 1 = Seleccionado
    }
}
