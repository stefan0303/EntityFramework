using System.Collections.Generic;
using System.Linq;

namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class CarsWithTheirListOfPartsDto
    {

        public CarDto Car { get; set; }
        public IEnumerable<PartDto> Parts { get; set; }

        public override string ToString()
        {
            var parts = Parts.Select(p => "--Part Name: " + p.Name + "\n--Part Price: " + p.Price);

            return $"Car: {Car.Make} {Car.Model}\n" +
                   $"Travelled Distance: {Car.TravelledDistance}\n-Parts:\n" +
                   $"{string.Join("\n", parts)}";
        }
    }
}
