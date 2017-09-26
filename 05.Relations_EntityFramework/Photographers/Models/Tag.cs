using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Photographers.Models
{
    
  public  class Tag
  {     
        public Tag()
        {
            this.Albums =new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }
        [Tag]
        public string Label { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
