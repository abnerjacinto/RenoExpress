using AutoMapper;
using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.DTOs;

namespace RenoExpress.Stock.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Register a mapping relation, Source ---> Destination     

            CreateMap<ProductStock, StockDTO>();

            CreateMap<StockDTO,ProductStock>();

        }


    }
}
