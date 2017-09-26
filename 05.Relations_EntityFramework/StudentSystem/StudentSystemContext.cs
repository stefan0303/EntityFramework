using StudentSystem.Models;

namespace StudentSystem
{
    using System.Data.Entity;

    public class StudentSystemContext : DbContext
    {
        
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {

        }
        
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resoursce> Resoursces { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

    }
}