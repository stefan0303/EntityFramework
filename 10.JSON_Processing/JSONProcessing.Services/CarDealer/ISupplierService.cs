using JSONProcessing.Models.CarDealer;
using JSONProcessing.Models.CarDealer.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public interface ISupplierService
    {
        IQueryable<Supplier> GetAllSuppliers();

        IEnumerable<LocalSuppliersDto> LocalSuppliers();
    }
}