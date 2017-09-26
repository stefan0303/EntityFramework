using AutoMapper;
using JSONProcessing.Models.ProductsShop.Dtos;

namespace JSONProcessing.Common.MappingProfiles
{
    class UsersAndProductsDtoProfile : Profile
    {
        public UsersAndProductsDtoProfile()
        {
            CreateMap<UserProductsDto, UsersAndProductsDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));
        }
    }
}
