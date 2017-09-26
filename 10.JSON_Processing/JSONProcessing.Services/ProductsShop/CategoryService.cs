using AutoMapper.QueryableExtensions;
using JSONProcessing.Data;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public class CategoryService : ICategoryService
    {
        private readonly IProductsShopContext _productsShopContext;
        public CategoryService()
        {
            _productsShopContext = NinjectCommon.Kernel.Get<ProductsShopContext>();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _productsShopContext.Categories;
        }

        public IEnumerable<CategoriesByProductsCountDto> CategoriesByProductsCount()
        {
            return GetAllCategories()
                .OrderBy(c => c.Name)
                .ProjectTo<CategoriesByProductsCountDto>()
                .ToList();
        }
    }
}
