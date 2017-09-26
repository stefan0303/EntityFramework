using AutoMapper.QueryableExtensions;
using JSONProcessing.Data.CarDealer;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public class SupplierService : ISupplierService
    {
        private readonly ICarDealerContext _carDealerContext;

        public SupplierService()
        {
            _carDealerContext = NinjectCommon.Kernel.Get<CarDealerContext>();
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return _carDealerContext.Suppliers;
        }

        public IEnumerable<LocalSuppliersDto> LocalSuppliers()
        {
            return GetAllSuppliers()
                .ProjectTo<LocalSuppliersDto>()
                .ToList();
        }
    }
}
