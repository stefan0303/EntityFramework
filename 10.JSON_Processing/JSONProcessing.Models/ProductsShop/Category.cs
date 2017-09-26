using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSONProcessing.Models.ProductsShop
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(500)]
        [MinLength(3)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
