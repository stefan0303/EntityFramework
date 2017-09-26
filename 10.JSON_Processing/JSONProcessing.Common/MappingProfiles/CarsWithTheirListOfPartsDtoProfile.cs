using AutoMapper;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;

namespace JSONProcessing.Common.MappingProfiles
{
    public class CarsWithTheirListOfPartsDtoProfile : Profile
    {
        public CarsWithTheirListOfPartsDtoProfile()
        {
            CreateMap<Car, CarsWithTheirListOfPartsDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.Parts));
        }
    }
}
