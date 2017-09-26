using System.ComponentModel.DataAnnotations.Schema;

namespace JSONProcessing.Models.CarDealer
{
    public class Sale
    {
        public int SaleId { get; set; }

        public decimal Discount { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
