namespace OnisCatalog.Orders.Models
{
    public class Basket
    {

        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public int TotalItems => _items.Sum(i => i.Quantity);


    }
}
