using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _9.Hospital.Models
{
  public  class Doctor
    {
      public Doctor()//each visitation, can be performed by only one doctor!
        {
            this.Visitations=new List<Visitation>();
        }
        public ICollection<Visitation> Visitations { get; set; }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }
    }
}
