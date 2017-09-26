
using LocalStore.Models;

namespace Sales
{
    using System.Data.Entity;


    public class SalesContext : DbContext
    {
       
        public SalesContext()
            : base("name=SalesContext")
        {
            //CreateDatabaseIfNotExists
            Database.SetInitializer<SalesContext>(new CreateDatabaseIfNotExists<SalesContext>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<StoreLocation> StoreLocations { get; set; }

        public DbSet<Sale> Sales { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

}