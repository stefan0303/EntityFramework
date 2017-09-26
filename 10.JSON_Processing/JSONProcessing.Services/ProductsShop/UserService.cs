using AutoMapper.QueryableExtensions;
using JSONProcessing.Data;
using JSONProcessing.Models.ProductsShop;
using JSONProcessing.Models.ProductsShop.Dtos;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Services.ProductsShop
{
    public class UserService : IUserService
    {
        private readonly IProductsShopContext _productsShopContext;

        public UserService()
        {
            _productsShopContext = NinjectCommon.Kernel.Get<ProductsShopContext>();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _productsShopContext.Users;
        }

        // Dang it. Mapping uses IGrouping<SellerGroupDto, Product> Instead of 
        // IGrouping<SellerGroupDto, User>
        public IEnumerable<SuccessfullySoldProductsDto> SuccessfullySoldProducts()
        {
            var successfullySoldProducts = GetAllUsers()
                .SelectMany(u => u.SoldProducts.Where(p => p.Buyer != null))
                .GroupBy(p => new SellerGroupDto
                {
                    FirstName = p.Seller.FirstName,
                    LastName = p.Seller.LastName
                })
                .ProjectTo<SuccessfullySoldProductsDto>()
                .OrderBy(sspd => sspd.LastName)
                .ThenBy(sspd => sspd.FirstName)
                .ToList();

            return successfullySoldProducts.ToList();
        }

        public UsersAndProductsDto UsersAndProducts()
        {
            var users = GetAllUsers()
               .Where(u => u.SoldProducts.Any())
               .SelectMany(u => u.SoldProducts
                    .GroupBy(g => new
                    {
                        g.Seller.FirstName,
                        g.Seller.LastName,
                        g.Seller.Age
                    })
                    .Select(sp => new UserProductsDto
                    {
                        FirstName = sp.Key.FirstName,
                        LastName = sp.Key.LastName,
                        Age = sp.Key.Age,
                        SoldProducts = new ProductCountDto
                        {
                            Count = u.SoldProducts.Count,
                            Products = u.SoldProducts
                            .Select(g => new ProductDto
                            {
                                Price = g.Price,
                                Name = g.Name
                            })
                        }
                    }))
                    .OrderByDescending(o => o.SoldProducts.Count)
                    .ThenBy(o => o.LastName)
                    .ToList();

            return new UsersAndProductsDto { Users = users };
        }
    }
}
