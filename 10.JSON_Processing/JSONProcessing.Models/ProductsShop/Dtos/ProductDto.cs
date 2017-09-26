namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}\n---     Product Price: {Price}";
        }
    }
}
