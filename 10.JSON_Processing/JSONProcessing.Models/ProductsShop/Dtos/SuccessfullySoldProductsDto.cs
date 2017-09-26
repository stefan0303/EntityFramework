using System.Collections.Generic;

namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class SuccessfullySoldProductsDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<ProductBuyerDto> SoldProducts { get; set; }

        public override string ToString()
        {
            return $"Seller: {FirstName ?? "[no name]"} {LastName}\n-{string.Join("\n-", SoldProducts)}";
        }
    }
}
