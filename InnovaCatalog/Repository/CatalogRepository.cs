using AutoMapper;
using InnovaCatalog.DbContexts;
using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace InnovaCatalog.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CatalogRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CatalogDto> CreateUpdateCatalog(CatalogDto catalogDto)
        {
            //Convertir Dto a Modelo
            CatalogItem catalogItem = _mapper.Map<CatalogDto, CatalogItem>(catalogDto);
            if (catalogItem.CatalogId > 0)// si mayor a 0, es update
            {
                _db.CatalogItems.Update(catalogItem);
            }
            else {
                _db.CatalogItems.Add(catalogItem);
            }
            await _db.SaveChangesAsync();
            //Convertir Modelo a Dto
            return _mapper.Map<CatalogItem, CatalogDto>(catalogItem);
        }

        public async Task<bool> DeleteCatalog(int catalogId)
        {
            try
            {
                CatalogItem catalogDto = await _db.CatalogItems.FirstOrDefaultAsync(x=>x.CatalogId == catalogId);
                if (catalogDto == null)
                {
                    return false;
                }
                _db.CatalogItems.Remove(catalogDto);
                _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }

        public async Task<CatalogDto> GetCatalogById(int catalogId)
        {
            CatalogItem catalogItem = await _db.CatalogItems.Where(x=>x.CatalogId== catalogId).FirstOrDefaultAsync();
            return _mapper.Map<CatalogDto>(catalogItem);
        }

        public async Task<IEnumerable<CatalogDto>> GetCatalogs()
        {
            List < CatalogItem >  catalogList= await _db.CatalogItems.ToListAsync();
            return _mapper.Map<List<CatalogDto>>(catalogList);//Catalog item a catalog DTO
        }
    }
}
