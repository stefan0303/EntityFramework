using System;
using System.Linq;

namespace Exercises_EntityFramework
{
    class Program
    {
        static void Main()
        {

            //01.new object class Person
            //Person stefan = new Person("Stefan",23);
            // 02.
            //Console.WriteLine(stefan.Name);
            //Console.WriteLine(stefan.Age);

            //03
            //Family stefanovi =new Family();
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split().ToArray();
            //    Person person=new Person(input[0],Convert.ToInt32(input[1]));
            //    stefanovi.AddMember(person);
            //}
            //Console.WriteLine();
            //stefanovi.GetOldestMember();

            //04
            //string nameStudent = Console.ReadLine();
            //while (nameStudent!="End")
            //{
            //    Student student =new Student();
            //    student.Name = nameStudent;

            //    nameStudent = Console.ReadLine();
            //}
            // Console.WriteLine(Student.countStudents);
            //05
            // Calculation.Calculate();
            //06

            string[] input = Console.ReadLine().Split().ToArray();
            while (input[0] != "End")
            {
                double first = Convert.ToDouble(input[1]);
                double second = Convert.ToDouble(input[2]);
                switch (input[0])
                {
                    case "Sum":
                        Console.WriteLine("{0:f2}", MathUtilities.Sum(first, second));

                        break;
                    case "Multiply":
                        Console.WriteLine("{0:f2}", MathUtilities.Multiply(first, second));
                        break;
                    case "Percentage":
                        Console.WriteLine("{0:f2}", MathUtilities.Percentage(first, second));
                        break;
                    case "Divide":
                        Console.WriteLine("{0:f2}", MathUtilities.Divide(first, second));
                        break;
                    case "Subtract":
                        Console.WriteLine("{0:f2}", MathUtilities.Substract(first, second));
                        break;
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
