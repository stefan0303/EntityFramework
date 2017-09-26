using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Photographers.Models
{
  public  class Photographer
    {
        public Photographer()
        {
            this.Albums =new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }


    }
}
