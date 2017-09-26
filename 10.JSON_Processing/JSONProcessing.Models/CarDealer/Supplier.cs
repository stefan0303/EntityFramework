using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSONProcessing.Models.CarDealer
{
    public class Supplier
    {
        public Supplier()
        {
            Parts = new HashSet<Part>();
        }

        public int SupplierId { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
