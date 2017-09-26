namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class SaleDto
    {
        public string CustomerName { get; set; }

        public double Discount { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get; set; }
    }
}
