using JSONProcessing.Models.CarDealer;

namespace JSONProcessing.Data.CarDealer
{
    using System.Data.Entity;

    public class CarDealerContext : DbContext, ICarDealerContext
    {
        public CarDealerContext() : base("name=CarDealerContext")
        {
            Database.SetInitializer(new SeedOnInit());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Parts)
                .WithMany(p => p.Cars)
                .Map(m => m.ToTable("PartCars")
                    .MapLeftKey("PartId")
                    .MapRightKey("CarId"));

            base.OnModelCreating(modelBuilder);
        }
    }

}