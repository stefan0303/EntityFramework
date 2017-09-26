using System;
using Grigotts_Database.Models;

namespace Grigotts_Database
{
    class Program
    {
        static void Main()
        {
            WizardDeposits dumpledore = new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 1,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false
            };

            var context =new GringottsContext();
            context.WizardDeposits.Add(dumpledore);
            context.SaveChanges();

        }
    }
}
