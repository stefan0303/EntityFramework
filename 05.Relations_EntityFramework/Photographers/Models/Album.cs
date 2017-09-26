using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Photographers.Models
{
   public class Album
    {
        public Album()
        {
                this.Pictures =new HashSet<Picture>();
                this.Tags =new HashSet<Tag>();
                this.Photographers = new HashSet<Photographer>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackGroundColor { get; set; }

        public bool IsPublic { get; set; }

        public bool TestField { get; set; }

        //public  virtual Photographer OwnerId { get; set; } //one album can have only Photographer
        public virtual ICollection<Photographer> Photographers { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
