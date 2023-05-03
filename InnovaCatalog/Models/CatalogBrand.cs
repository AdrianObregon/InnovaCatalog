using System.ComponentModel.DataAnnotations;

namespace InnovaCatalog.Models
{
    public class CatalogBrand
    {
        [Key]
        public int CatalogBrandId { get; set; }
        public string CatalogBrandName { get; set;}
    }
}
