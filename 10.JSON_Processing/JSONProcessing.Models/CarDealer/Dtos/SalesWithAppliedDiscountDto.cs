namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class SalesWithAppliedDiscountDto
    {

        public CarDto Car { get; set; }

        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get; set; }

        public override string ToString()
        {
            return $"Car:\n- Make: {Car.Make}\n- Model: {Car.Model}\n" +
                   $"- Travelled Distance: {Car.TravelledDistance}\n" +
                   $"Customer Name: {CustomerName}\nDiscount: {Discount}\n" +
                   $"Price: {Price}\nPrice with Discount: {PriceWithDiscount}";
        }
    }
}
