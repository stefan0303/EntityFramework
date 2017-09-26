using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();

        IEnumerable<CategoriesByProductsCountDto> CategoriesByProductsCount();
    }
}
