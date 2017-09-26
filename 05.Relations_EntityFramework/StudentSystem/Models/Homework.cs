using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public enum ContentType
    {
        Application, Pdf, Zip
    }
    public class Homework
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]            //to Do options (application/pdf/zip)
        public ContentType ContentType { get; set; }
        [Required]
        public DateTime SubmmitionDate { get; set; }

        public virtual Course Course { get; set; }//!!!!

        public virtual Student Student { get; set; }//!!!


    }
}
