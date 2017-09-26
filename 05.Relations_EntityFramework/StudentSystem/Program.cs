using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using StudentSystem.Models;

namespace StudentSystem
{

    class Program
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();


            // SeedData(context);
            // AllStudentsAndHomeworkSubmissions(context);
            // AllCoursesWithCorrespondingResources(context);
            // AllCoursesWithMoreThan5Resources(context);
            // AllCoursesActiveOnGivenDate(context,DateTime.Today);
            // AllStudentsWithCoursesInfo(context);


        }
        //03.01
        static void AllStudentsAndHomeworkSubmissions(StudentSystemContext context)
        {
            var course = context.Courses;
            foreach (var c in course)
            {
                foreach (var s in c.Students)
                {
                    Console.WriteLine(s.Name);
                    if (s.Homeworks.Count == 0)
                    {
                        Console.WriteLine("--No homeworks");
                    }
                    foreach (var home in s.Homeworks)
                    {
                        Console.WriteLine("--" + home.Content);
                    }
                }
            }
        }
        //03.02
        static void AllCoursesWithCorrespondingResources(StudentSystemContext context)
        {
            var courses = context.Courses.OrderBy(c => c.StartDate).ThenByDescending(c => c.EndDate);
            foreach (var course in courses)
            {
                Console.WriteLine("Course Name: " + course.Name);
                Console.WriteLine("Course Description: " + course.Description);
                foreach (var resource in course.Resoursces)
                {
                    Console.WriteLine("  Resorce Name : " + resource.Name);
                    Console.WriteLine("    --ResourceType : " + resource.ResourceType);
                    Console.WriteLine("    --Url : " + resource.Url);
                }
            }
        }
        //03.03
        static void AllCoursesWithMoreThan5Resources(StudentSystemContext context)
        {
            var courses = context.Courses.Where(r => r.Resoursces.Count > 5)
                .OrderByDescending(c => c.Resoursces.Count)
                .ThenByDescending(c => c.StartDate);
            foreach (var course in courses)
            {
                Console.WriteLine("Course Name: " + course.Name);
                Console.WriteLine("Nember of resurces: " + course.Resoursces.Count);

            }
        }
        //03.04
        private static void AllCoursesActiveOnGivenDate(StudentSystemContext context, DateTime activeDate)
        {
            var courses = context.Courses
                .Where(course => course.StartDate <= activeDate && course.EndDate >= activeDate)
                .OrderBy(course => course.Students.Count)
                .Select(course => new
                {
                    course.Name,
                    course.StartDate,
                    course.EndDate,
                    Duration = SqlFunctions.DateDiff("day", course.StartDate, course.EndDate),
                    StudentsCount = course.Students.Count
                });

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.StartDate} {course.EndDate} {course.Duration} - {course.StudentsCount}");
            }
        }
        //03.05
        private static void AllStudentsWithCoursesInfo(StudentSystemContext context)
        {
            var students = context.Students
                .OrderByDescending(student => student.Courses.Sum(course => course.Price))
                .ThenByDescending(student => student.Courses.Count)
                .ThenBy(student => student.Name);

            foreach (Student student in students)
            {
                if (student.Courses.Count != 0)
                {
                    Console.WriteLine(
                        $"{student.Name} - {student.Courses.Count} - {student.Courses.Sum(course => course.Price)} - {student.Courses.Average(course => course.Price)}");
                }
            }
        }

        //02 Seed Some Data in the Database 
        static void SeedData(StudentSystemContext context)
        {
            context.Courses.Add(new Course
            {
                Name = "C#",
                Description = "Learn C#",
                StartDate = DateTime.Parse("2016/01/01"),
                EndDate = DateTime.Parse("2016/04/04"),
                Price = 178.54m,
                Students = new List<Student>
                {
                    new Student
                    {
                        Name = "Stefan",
                        PhoneNumber = "123-456",
                        RegistrationDate = DateTime.Now,
                        Birthday = DateTime.Parse("1983/02/02")
                    },
                    new Student
                    {
                        Name = "Ivan",
                        PhoneNumber = "123-456",
                        RegistrationDate = DateTime.Now,
                        Birthday = DateTime.Parse("1983/02/02"),
                        Homeworks = new List<Homework>
                        {
                            new Homework
                            {
                                Content = "c# homework", ContentType = ContentType.Application, SubmmitionDate = DateTime.Parse("2016/01/26")
                            },
                            new Homework
                            {
                                 Content = "This homework", ContentType = ContentType.Pdf, SubmmitionDate = DateTime.Parse("2017/01/15")
                            }
                        }
                    },
                    new Student
                    {
                        Name = "Dragan",
                        PhoneNumber = "123-456",
                        RegistrationDate = DateTime.Now,
                        Birthday = DateTime.Parse("1983/02/02"),
                        Homeworks = new List<Homework>
                        {
                            new Homework
                            {
                                Content = "Java homework", ContentType = ContentType.Application, SubmmitionDate = DateTime.Parse("2016/01/26")
                            },
                            new Homework
                            {
                                 Content = "My homework", ContentType = ContentType.Pdf, SubmmitionDate = DateTime.Parse("2017/01/15")
                            }
                        }
                    }
                },
                Resoursces = new List<Resoursce>
                {
                    new Resoursce
                        {
                            Name = "This resurce",
                            ResourceType = Resource.Document,
                            Url = "usadl"
                        },
                        new Resoursce
                        {
                            Name = "No my resurce",
                            ResourceType = Resource.Other,
                            Url = "sdadasads"
                        }
                }
            });
            context.SaveChanges();

        }
    }
}
