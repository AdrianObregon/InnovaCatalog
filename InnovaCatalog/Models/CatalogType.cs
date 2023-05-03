using System.ComponentModel.DataAnnotations;

namespace InnovaCatalog.Models
{
    public class CatalogType
    {
        [Key]
        public int CatalogTypeId { get; set; }
        public string CatalogTypeName { get; set; }
    }
}
