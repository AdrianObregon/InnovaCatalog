using System.ComponentModel.DataAnnotations;

namespace OnisCatalog.Orders.Models
{
    public class BasketItem
    {

        [Key]
        public int BasketItemId { get; set; }
        
        public int Quantity { get; set; }

        public double Price{ get; set; } 
        
        public int CatalogItemId { get; set; }

        public Basket BasketId { get; set; }
    }
}
