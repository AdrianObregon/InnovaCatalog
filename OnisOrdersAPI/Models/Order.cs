using System.ComponentModel.DataAnnotations;

namespace OnisOrdersAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int BuyerId { get;  set; }
        public DateTimeOffset OrderDate { get;  set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get;  set; }//Owns Address -Configure in dbcontext

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    }
}
