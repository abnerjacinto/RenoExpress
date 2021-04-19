using AutoMapper;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.DTOs;

namespace RenoExpress.Sales.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Register a mapping relation, Source ---> Destination     

            CreateMap<Sale, SaleDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(origin => origin.CreatedDate)); ;
            CreateMap<SaleDetail, SaleDetailDTO>();

            CreateMap<SaleDTO,Sale>();
            CreateMap<SaleDetailDTO, SaleDetail>();

        }


    }
}
