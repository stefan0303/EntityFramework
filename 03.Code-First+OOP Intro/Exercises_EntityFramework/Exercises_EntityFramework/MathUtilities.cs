
namespace Exercises_EntityFramework
{
   public class MathUtilities
    {
        public static double Sum(double first, double second)
        {
            return first + second;
        }
        public static double Multiply(double first, double second)
        {
            return first * second;
        }
        public static double Percentage(double first, double second)
        {
            double result = first * ( second/ 100);
            return result;


        }
        public static double Divide(double first, double second)
        {
            return first / second;
        }
        public static double Substract(double first, double second)
        {
            return first -second; 
        }
    }
}
