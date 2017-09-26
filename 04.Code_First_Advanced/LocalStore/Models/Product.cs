using System.Collections.Generic;

namespace LocalStore.Models
{
    public  class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Sale> SalesOfProduct { get; set; }//can have many sales
    }
}

