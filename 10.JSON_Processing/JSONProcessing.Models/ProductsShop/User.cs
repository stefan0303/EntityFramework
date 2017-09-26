using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSONProcessing.Models.ProductsShop
{
    public class User
    {
        public User()
        {
            Friends = new HashSet<User>();
            BoughtProducts = new HashSet<Product>();
            SoldProducts = new HashSet<Product>();
        }

        public int UserId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(155)]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<Product> BoughtProducts { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; }
    }
}
