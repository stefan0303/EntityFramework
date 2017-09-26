using AutoMapper;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;

namespace JSONProcessing.Common.MappingProfiles
{
    class ProductCountDtoProfile : Profile
    {
        public ProductCountDtoProfile()
        {
            CreateMap<User, ProductCountDto>()
                    .ForMember(dest => dest.Count,
                        opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Products,
                        opt => opt.MapFrom(src => src.SoldProducts));
        }
    }
}
