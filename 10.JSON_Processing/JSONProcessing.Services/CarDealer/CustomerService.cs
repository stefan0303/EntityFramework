using AutoMapper.QueryableExtensions;
using JSONProcessing.Common.Utils;
using JSONProcessing.Data.CarDealer;
using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICarDealerContext _carDealerContext;

        public CustomerService()
        {
            _carDealerContext = NinjectCommon.Kernel.Get<CarDealerContext>();
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _carDealerContext.Customers;
        }

        public IEnumerable<CustomerDto> OrderedCustomers()
        {
            var orderedCustomers = GetAllCustomers()
                .ProjectTo<CustomerDto>()
                .ToList()
                .OrderBy(x => x, new CustomerDtoComparer());

            return orderedCustomers;
        }

        public IEnumerable<TotalSalesByCustomerDto> TotalSalesByCustomer()
        {
            return GetAllCustomers()
                .ProjectTo<TotalSalesByCustomerDto>()
                .OrderByDescending(t => t.SpentMoney)
                .ThenByDescending(t => t.BoughtCars)
                .ToList();
        }
    }
}
