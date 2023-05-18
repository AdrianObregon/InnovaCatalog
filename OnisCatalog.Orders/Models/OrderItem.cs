using System.ComponentModel.DataAnnotations;

namespace OnisCatalog.Orders.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public CatalogItemOrdered ItemOrdered { get; private set; }
        
        public int UnitPrices { get; set; }
        public int units { get; set; }

    }
}
