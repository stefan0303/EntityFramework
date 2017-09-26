using AutoMapper;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using System.Linq;

namespace JSONProcessing.Common.MappingProfiles
{
    class TotalSalesByCustomerDtoProfile : Profile
    {
        public TotalSalesByCustomerDtoProfile()
        {
            CreateMap<Customer, TotalSalesByCustomerDto>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                    .ForMember(dest => dest.SpentMoney,
                        opt => opt.MapFrom(src =>
                            src.Sales.Sum(s =>
                                s.Car.Parts.Sum(p => p.Price) -
                                (s.Car.Parts.Sum(p => p.Price) * s.Discount))));
        }
    }
}
