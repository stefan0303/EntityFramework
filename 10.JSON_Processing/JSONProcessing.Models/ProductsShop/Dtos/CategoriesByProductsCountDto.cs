namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class CategoriesByProductsCountDto
    {
        public string Category { get; set; }

        public int ProductCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalRevenue { get; set; }

        public override string ToString()
        {
            return $"Category: {Category}\nProducts count: {ProductCount}" +
                   $"\nAverage price: {AveragePrice}\nTotal revenue: {TotalRevenue}";
        }
    }
}
