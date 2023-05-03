using AutoMapper;
using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;

namespace InnovaCatalog
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => { 
            config.CreateMap<CatalogItem,CatalogDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
