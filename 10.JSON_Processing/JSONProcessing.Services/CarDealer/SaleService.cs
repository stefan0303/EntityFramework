using AutoMapper.QueryableExtensions;
using JSONProcessing.Data.CarDealer;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public class SaleService : ISaleService
    {
        private readonly ICarDealerContext _carDealerContext;

        public SaleService()
        {
            _carDealerContext = NinjectCommon.Kernel.Get<CarDealerContext>();
        }

        public IQueryable<Sale> GetAllSales()
        {
            return _carDealerContext.Sales;
        }

        public IEnumerable<SalesWithAppliedDiscountDto> SalesWithAppliedDiscount()
        {
            return GetAllSales()
                .ProjectTo<SalesWithAppliedDiscountDto>()
                .ToList();
        }
    }
}
