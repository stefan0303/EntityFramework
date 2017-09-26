using JSONProcessing.Models.ProductsShop;

namespace JSONProcessing.Data
{
    using System.Data.Entity;

    public class ProductsShopContext : DbContext, IProductsShopContext
    {
        public ProductsShopContext() : base("name=ProductsShopContext")
        {
            Database.SetInitializer(new SeedOnInit());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m => m.ToTable("UserFirends")
                    .MapLeftKey("UserId")
                    .MapRightKey("FriendId"));

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(m => m.ToTable("CategoryProducts")
                    .MapLeftKey("CategoryId")
                    .MapRightKey("ProductId"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOptional(p => p.Buyer)
                .HasForeignKey(p => p.BuyerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SoldProducts)
                .WithRequired(p => p.Seller)
                .HasForeignKey(p => p.SellerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}