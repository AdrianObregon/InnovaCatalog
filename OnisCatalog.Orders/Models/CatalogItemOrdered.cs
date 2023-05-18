using System.ComponentModel.DataAnnotations;

namespace OnisCatalog.Orders.Models
{
    public class CatalogItemOrdered
    {
        [Key]
        public int CatalogItemOrderedId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }

    }
}
