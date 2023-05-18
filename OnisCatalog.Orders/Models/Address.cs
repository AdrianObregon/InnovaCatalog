using System.ComponentModel.DataAnnotations;

namespace OnisCatalog.Orders.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string street { get; set; }
        public string city { get; set; }
    }
}
