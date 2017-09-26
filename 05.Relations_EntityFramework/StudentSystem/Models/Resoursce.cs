using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
   public  enum Resource// Not working
    {      
        Video,
        Presentation,
        Document,
        Other
    }
  public  class Resoursce
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]//Todo have options (video / presentation / document / other)
        public  Resource ResourceType { get; set; }
        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
