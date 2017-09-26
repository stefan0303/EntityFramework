using AutoMapper.QueryableExtensions;
using JSONProcessing.Data;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public class ProductService : IProductService
    {
        private readonly IProductsShopContext _productsShopContext;

        public ProductService()
        {
            _productsShopContext = NinjectCommon.Kernel.Get<ProductsShopContext>();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productsShopContext.Products;
        }

        public IEnumerable<ProductsInRangeDto> ProductsInRange(int bottom, int top, bool inclusive)
        {
            IQueryable<ProductsInRangeDto> products;

            if (inclusive)
            {
                products = GetAllProducts()
                    .Where(p => p.Price >= bottom && p.Price <= top)
                    .OrderBy(p => p.Price)
                    .ProjectTo<ProductsInRangeDto>();
            }
            else
            {
                products = _productsShopContext.Products
                    .Where(p => p.Price > bottom && p.Price < top)
                    .OrderBy(p => p.Price)
                    .ProjectTo<ProductsInRangeDto>();
            }


            return products.ToList();
        }
    }
}
