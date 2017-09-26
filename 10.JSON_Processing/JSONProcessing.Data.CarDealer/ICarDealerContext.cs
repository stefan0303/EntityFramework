using JSONProcessing.Models.CarDealer;
using System.Data.Entity;

namespace JSONProcessing.Data.CarDealer
{
    public interface ICarDealerContext
    {
        DbSet<Car> Cars { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Sale> Sales { get; set; }

        DbSet<Supplier> Suppliers { get; set; }

        DbSet<Part> Parts { get; set; }
    }
}