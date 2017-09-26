using System.ComponentModel.DataAnnotations;

namespace _9.Hospital.Models
{
   public class Diagnose
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }
    }
}
