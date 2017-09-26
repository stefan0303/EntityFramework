using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSONProcessing.Models.CarDealer
{
    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
