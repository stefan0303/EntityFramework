using System;
using System.ComponentModel.DataAnnotations;

namespace _9.Hospital.Models
{
   public class Visitation
    {
       [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }
    }
}
