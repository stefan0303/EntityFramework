
using _9.Hospital.Models;

namespace _9.Hospital
{
    class Program
    {
        static void Main()
        {
            HospitalContext contex =new HospitalContext();

            contex.Medicaments.Add(new Medicament { Name = "Paracetamol" });
            contex.SaveChanges();
        }
    }
}
