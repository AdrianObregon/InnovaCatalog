using System.ComponentModel.DataAnnotations;

namespace OnisOrdersAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string BuyerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }//Owns Address -Configure in dbcontext

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    }
}
