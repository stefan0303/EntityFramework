using System.Collections.Generic;

namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class ProductCountDto
    {
        public int Count { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        public override string ToString()
        {
            return $"Product count: {Count}\n--    Products:\n---    {string.Join("\n---    ", Products)}";
        }
    }
}
