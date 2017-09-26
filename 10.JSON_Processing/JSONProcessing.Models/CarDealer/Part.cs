using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSONProcessing.Models.CarDealer
{
    public class Part
    {
        public Part()
        {
            Cars = new HashSet<Car>();
        }

        public int PartId { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
