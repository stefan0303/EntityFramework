using System;

namespace LocalStore.Models
{
   public class Sale
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int StoreLocationId { get; set; }

        public DateTime Date { get; set; }

    }
}
