using InnovaCatalog.Models.Dto;

namespace InnovaCatalog.Repository
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogDto>> GetCatalogs();
        Task<CatalogDto> GetCatalogById(int catalogId);
        Task<CatalogDto> CreateUpdateCatalog(CatalogDto catalogDto);
        Task<bool> DeleteCatalog(int productId);
    }
}
