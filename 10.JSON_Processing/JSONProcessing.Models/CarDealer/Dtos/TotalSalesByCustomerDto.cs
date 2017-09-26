namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class TotalSalesByCustomerDto
    {
        public string FullName { get; set; }

        public int BoughtCars { get; set; }

        public decimal SpentMoney { get; set; }

        public override string ToString()
        {
            return $"Customer: {FullName}\nBought Cars: {BoughtCars}\nSpent Money: {SpentMoney}";
        }
    }
}
