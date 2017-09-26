using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSONProcessing.Models.CarDealer
{
    public class Car
    {
        public Car()
        {
            Parts = new HashSet<Part>();
        }

        public int CarId { get; set; }

        [StringLength(200)]
        public string Make { get; set; }

        [StringLength(200)]
        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
