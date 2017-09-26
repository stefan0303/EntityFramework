using AutoMapper;
using JSONProcessing.Common.MappingProfiles;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System;


namespace JSONProcessing.Common
{
    public static class AutoMapperCommon
    {
        private static Mapper MapperInstance { get; set; }

        public static IRuntimeMapper Mapper { get; private set; }

        public static void InitializeMapper()
        {
            if (MapperInstance != null)
            {
                throw new MethodAccessException("AutoMapper is already instantiated!");
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                // ProductsShop Models Mappings
                cfg.AddProfile<CategoriesByProductsCountDtoProfile>();
                cfg.AddProfile<SuccessfullySoldProductsDtoProfile>();

                // ---------------- SuccessfullySoldProductsDto
                cfg.CreateMap<Product, ProductBuyerDto>()
                    .ForMember(dest => dest.BuyerFirstName, opt => opt.MapFrom(src => src.Buyer.FirstName))
                    .ForMember(dest => dest.BuyerLastName, opt => opt.MapFrom(src => src.Buyer.LastName));

                // ----------------
                cfg.CreateMap<Product, ProductsInRangeDto>()
                    .ForMember(dest => dest.Seller,
                        opt => opt.MapFrom(p => p.Seller.FirstName + " " + p.Seller.LastName));

                // CarRental Models Mappings
                cfg.AddProfile<TotalSalesByCustomerDtoProfile>();
                cfg.AddProfile<SalesWithAppliedDiscountDtoProfile>();
                cfg.AddProfile<CarsWithTheirListOfPartsDtoProfile>();

                cfg.CreateMap<Car, CarsFromMakeDto>();
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<Part, PartDto>();

                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(dest => dest.Sales, opt => opt.Ignore());

                cfg.CreateMap<Supplier, LocalSuppliersDto>()
                    .ForMember(dest => dest.PartsCount,
                        opt => opt.MapFrom(src => src.Parts.Count));
            });


            MapperInstance = AutoMapper.Mapper.Instance as Mapper;

            Mapper = MapperInstance.DefaultContext.Mapper;
        }

    }
}
