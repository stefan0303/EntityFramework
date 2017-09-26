using JSONProcessing.Models.ProductsShop;
using System.Data.Entity;

namespace JSONProcessing.Data
{
    public interface IProductsShopContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<User> Users { get; set; }
    }
}