using JSONProcessing.Models.CarDealer.Dtos;
using System.Collections.Generic;

namespace JSONProcessing.Common.Utils
{
    public class CustomerDtoComparer : IComparer<CustomerDto>
    {
        public int Compare(CustomerDto x, CustomerDto y)
        {
            var birthdayCompare = x.BirthDate.CompareTo(y.BirthDate);

            if (birthdayCompare == 0)
            {
                return x.IsYoungDriver.CompareTo(y.IsYoungDriver);
            }

            return birthdayCompare;
        }
    }
}