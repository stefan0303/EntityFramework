namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class ProductBuyerDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string BuyerFirstName { get; set; }

        public string BuyerLastName { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}\nPrice: {Price}\n" +
                   $"Buyer Name: {BuyerFirstName ?? "[no name]"} {BuyerLastName}";
        }
    }
}
