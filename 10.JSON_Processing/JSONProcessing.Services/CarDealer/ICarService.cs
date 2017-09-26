using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public interface ICarService
    {
        IQueryable<Car> GetAllCars();

        IEnumerable<CarsFromMakeDto> CarsFromMakeToyota();

        IEnumerable<CarsWithTheirListOfPartsDto> CarsWithTheirListOfParts();
    }
}