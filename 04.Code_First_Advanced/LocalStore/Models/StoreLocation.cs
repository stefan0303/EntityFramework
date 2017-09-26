using System.Collections.Generic;

namespace LocalStore.Models
{
  public  class StoreLocation
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Sale> StoreLocationSales { get; set; }
    }
}
