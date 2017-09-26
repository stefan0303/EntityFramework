using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        IEnumerable<ProductsInRangeDto> ProductsInRange(int bottom, int top, bool inclusive);
    }
}