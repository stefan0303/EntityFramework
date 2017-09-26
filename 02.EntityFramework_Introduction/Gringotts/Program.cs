using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts
{
    class Program
    {
        static void Main(string[] args)
        {
            GrindottsContext context=new GrindottsContext();
            using (context)
            {
                var grindotts = context.WizzardDeposits.Where(g=>g.DepositGroup=="Troll Chest").Select(g => g.FirstName.Substring(0,1)).Distinct();
                foreach (var VARIABLE in grindotts)
                {
                    Console.WriteLine(VARIABLE);
                }
            }
        }
    }
}
