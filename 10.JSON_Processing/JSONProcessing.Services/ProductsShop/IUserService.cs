using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        IEnumerable<SuccessfullySoldProductsDto> SuccessfullySoldProducts();

        UsersAndProductsDto UsersAndProducts();

    }
}