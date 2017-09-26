using AutoMapper;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System.Linq;

namespace JSONProcessing.Common.MappingProfiles
{
    class SuccessfullySoldProductsDtoProfile : Profile
    {
        public SuccessfullySoldProductsDtoProfile()
        {
            CreateMap<IGrouping<SellerGroupDto, Product>, SuccessfullySoldProductsDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Key.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Key.LastName))
                .ForMember(dest => dest.SoldProducts, opt =>
                {
                    opt.MapFrom(src => src.Select(x => x));
                });
        }
    }
}
