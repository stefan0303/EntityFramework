using AutoMapper;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using System.Linq;

namespace JSONProcessing.Common.MappingProfiles
{
    class SalesWithAppliedDiscountDtoProfile : Profile
    {
        public SalesWithAppliedDiscountDtoProfile()
        {
            CreateMap<Sale, SalesWithAppliedDiscountDto>()
                .ForMember(dest => dest.Car, opt => opt.ResolveUsing(src => src.Car))
                    .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Car.Parts.Sum(p => p.Price)))
                    .ForMember(dest => dest.PriceWithDiscount,
                        opt => opt.MapFrom(src =>
                            src.Car.Parts.Sum(p => p.Price) -
                            (src.Car.Parts.Sum(p => p.Price) * src.Discount)));
        }
    }
}
