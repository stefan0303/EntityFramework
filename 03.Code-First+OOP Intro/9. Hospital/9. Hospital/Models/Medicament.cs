using System.ComponentModel.DataAnnotations;

namespace _9.Hospital.Models
{
  public  class Medicament
    {
      [Key]
       public int Id { get; set; }

       public string Name { get; set; }


    }
}
