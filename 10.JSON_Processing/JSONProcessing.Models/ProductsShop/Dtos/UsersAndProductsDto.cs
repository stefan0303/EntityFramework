using System.Collections.Generic;

namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class UsersAndProductsDto
    {
        public int UsersCount => this.Users.Count;

        public ICollection<UserProductsDto> Users { get; set; }

        public override string ToString()
        {
            return $"Users count: {UsersCount}\nUsers:\n-  {string.Join("\n-  ", Users)}";
        }
    }
}
