using System;
using System.ComponentModel.DataAnnotations;

namespace Grigotts_Database.Models
{
   public class WizardDeposits
   {
       private int age;

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
        [MaxLength(1000)]
        public string Notes { get; set; }

       [Required]
       public int Age
       {
           get { return this.age;}
           set
           {
               if (value<0)
               {
                   throw new ArgumentException("Age can not be negative number!");
               }
                this.age = value;
           }

       }

       [MaxLength(100)]
        public string MagicWandCreator { get; set; }

        [Range(0, 32767)]
       public int MagicWandSize { get; set; }

       [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal DepositInterest { get; set; }

        public decimal DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
