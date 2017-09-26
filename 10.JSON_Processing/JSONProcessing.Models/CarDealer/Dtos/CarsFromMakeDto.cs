namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class CarsFromMakeDto
    {
        public int CarId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public override string ToString()
        {
            return $"Car ID: {CarId}\nMake: {Make}\nModel: {Model}\nTravelled Distance: {TravelledDistance}";
        }
    }
}
