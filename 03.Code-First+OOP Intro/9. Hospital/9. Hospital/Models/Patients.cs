using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _9.Hospital.Models
{
    public class Patients
    {
        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Image { get; set; }

        public bool HaveMedicalInsurance { get; set; }


        public string VisitaionComments { get; set; }

    }
}
