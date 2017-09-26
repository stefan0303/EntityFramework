namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class ProductsInRangeDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Seller { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}\nPrice: {Price}\nSeller: {Seller}";
        }
    }
}
