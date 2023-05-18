namespace OnisCatalog.Orders.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }
        public int AddressId { get; set; }


        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public int Total => _orderItems.Count;
    }
}
