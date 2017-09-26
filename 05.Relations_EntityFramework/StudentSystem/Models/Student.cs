﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
      
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

    }
}
