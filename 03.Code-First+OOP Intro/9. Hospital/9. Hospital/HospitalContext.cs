using _9.Hospital.Models;

namespace _9.Hospital
{
    using System.Data.Entity;
  
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {

        }
        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Patients> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }  
}