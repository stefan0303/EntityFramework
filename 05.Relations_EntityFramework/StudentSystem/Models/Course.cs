using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
  public  class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Resoursces =new HashSet<Resoursce>();
            this.Homeworks = new HashSet<Homework>();
        }            
        

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Resoursce> Resoursces { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
