using System.Collections.Generic;
using System.Text;
using EmployeeApp.DTOs;

namespace EmployeeAppModels.DTOs
{
    public class ManagerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDTO> Subordinates { get; set; }

        public int SuboridatesCount { get; set; }

        public override string ToString()
        {
           StringBuilder sb =new StringBuilder();
            
            sb.Append(this.FirstName+" "+this.LastName+" "+this.Subordinates.Count);
            foreach (var subordinate in this.Subordinates)
            {
                
                sb.AppendLine(subordinate.ToString());
            }
            return sb.ToString();
        }
    }
}
