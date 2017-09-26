using System;

namespace Exercises_EntityFramework
{
    class Calculation
    {
        private static double plancConstant = (6.62606896 - 34);
        private static double pi = 3.14159;

        public static void Calculate()
        {
            double result = plancConstant / (2 * pi);
            Console.WriteLine(result);
        }

    }
}
