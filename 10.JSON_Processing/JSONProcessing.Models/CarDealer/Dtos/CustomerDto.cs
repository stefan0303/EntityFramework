using System;
using System.Collections;
using System.Collections.Generic;

namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public override string ToString()
        {
            return $"Customer Id: {CustomerId}\nCustomer Name: {Name}" +
                   $"\nBirthDate: {BirthDate}\nIs Young Driver: {IsYoungDriver}" +
                   $"\nSales: {(IEnumerable)Sales ?? "[]"}";
        }


    }
}
