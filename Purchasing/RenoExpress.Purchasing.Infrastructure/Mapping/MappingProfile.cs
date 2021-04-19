using AutoMapper;
using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.DTOs;

namespace RenoExpress.Purchasing.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Register a mapping relation, Source ---> Destination     

            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(origin => origin.CreatedDate)); ;
            CreateMap<PurchaseDetail, PurchaseDetailDTO>();

            CreateMap<PurchaseDTO,Purchase>();
            CreateMap<PurchaseDetailDTO, PurchaseDetail>();

        }


    }
}
