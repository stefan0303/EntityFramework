using AutoMapper.QueryableExtensions;
using JSONProcessing.Data.CarDealer;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public class CarService : ICarService
    {
        private readonly ICarDealerContext _carDealerContext;

        public CarService()
        {
            _carDealerContext = NinjectCommon.Kernel.Get<CarDealerContext>();
        }

        public IQueryable<Car> GetAllCars()
        {
            return _carDealerContext.Cars;
        }

        public IEnumerable<CarsFromMakeDto> CarsFromMakeToyota()
        {
            return GetAllCars()
                .Where(c => c.Make.Equals("Toyota", StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarsFromMakeDto>()
                .ToList();
        }

        public IEnumerable<CarsWithTheirListOfPartsDto> CarsWithTheirListOfParts()
        {
            return GetAllCars()
                .ProjectTo<CarsWithTheirListOfPartsDto>()
                .ToList();
        }
    }
}