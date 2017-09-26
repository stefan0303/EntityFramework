using Grigotts_Database.Models;

namespace Grigotts_Database
{
    using System.Data.Entity;

    public class GringottsContext : DbContext
    {
   
        public GringottsContext()
            : base("name=Gringotts")
        {

        }

        public IDbSet<WizardDeposits> WizardDeposits { get; set; }


    }

    
}