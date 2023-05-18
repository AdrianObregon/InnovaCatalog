using AutoMapper;
using OnisOrdersAPI.Models;
using OnisOrdersAPI.Models.Dto;

namespace OnisOrdersAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
