using AutoMapper;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System.Linq;

namespace JSONProcessing.Common.MappingProfiles
{
    class CategoriesByProductsCountDtoProfile : Profile
    {
        public CategoriesByProductsCountDtoProfile()
        {
            CreateMap<Category, CategoriesByProductsCountDto>()
                    .ForMember(dest => dest.Category,
                        opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ProductCount,
                        opt => opt.MapFrom(src => src.Products.Count))
                    .ForMember(dest => dest.AveragePrice,
                        opt => opt.MapFrom(src => src.Products.Average(p => p.Price)))
                    .ForMember(dest => dest.TotalRevenue,
                        opt => opt.MapFrom(src => src.Products.Sum(p => p.Price)));
        }
    }
}
