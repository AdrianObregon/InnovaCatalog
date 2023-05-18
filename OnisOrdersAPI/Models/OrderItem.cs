namespace OnisOrdersAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public CatalogItemOrdered ItemOrdered { get; private set; }
    }
}
