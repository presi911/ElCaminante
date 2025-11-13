using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElCaminante.Domain.Entities
{
    [Table("Orders", Schema = "ELCAMINANTE")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public string DeliveryAddress { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalFee { get; set; }

    }
}