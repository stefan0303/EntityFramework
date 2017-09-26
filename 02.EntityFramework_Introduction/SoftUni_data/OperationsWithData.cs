using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2;

namespace SoftUni_data
{
    public class OperationsWithData
    {
        // 03.Employees Full Information
        public static void EmployeesFullInformation()
        {

            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                List<string> employees =
                    context.Employees.OrderBy(e => e.EmployeeID)
                        .Select(
                            e => e.FirstName + " " + e.LastName + " " + e.MiddleName + " " + e.JobTitle + " " + e.Salary)
                        .ToList();
                foreach (var id in employees)
                {
                    Console.WriteLine(id + "00");
                }
            }
        }
        //4.Employees with Salary Over 50 000
        public static void EmployeeswithSalaryOver50000()
        {
            SoftuniContext contex = new SoftuniContext();
            using (contex)
            {
                List<string> EmployeeswithSalaryOver50000 = contex.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName).ToList();
                foreach (var emp in EmployeeswithSalaryOver50000)
                {
                    Console.WriteLine(emp);
                }
            }

        }
        //05 Employees from Seattle
        public static void EmployeesfromSeattle()
        {
            SoftuniContext contex = new SoftuniContext();
            using (contex)
            {
                List<string> employeesfromSeattle =
                    contex.Employees.OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).Where(e => e.DepartmentID == 6).Select(e => e.FirstName + " " + e.LastName + " from " + e.Department.Name + " - $" + e.Salary).ToList();
                foreach (var name in employeesfromSeattle)
                {
                    Console.WriteLine(name);
                }
            }

        }
        //06.Adding a New Address and Updating Employee
        public static void AddingNewAddressUpdatingEmployee()
        {
            SoftuniContext contex = new SoftuniContext();
            using (contex)
            {
                var address = contex.Set<Address>();
                address.Add(new Address { AddressText = "Vitoshka 15", TownID = 4 });
                contex.SaveChanges();
                var result = contex.Employees.SingleOrDefault(e => e.LastName == "Nakov");
                if (result != null)
                {
                    result.AddressID = 292;
                    contex.SaveChanges();
                }
                var Findaddress = contex.Employees.OrderByDescending(e => e.AddressID).Select(e => e.Address.AddressText).Take(10);
                foreach (var add in Findaddress)
                {
                    Console.WriteLine(add);
                }

            }
        }
        //07.Find Employees in Period
        public static void FindEmployeesPeriod()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var employees =
                    context.Employees.Where(
                        e =>
                            e.Projects.Any(project => project.StartDate.Year <= 2003 && project.StartDate.Year >= 2001)
                    ).Take(30);
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Manager.FirstName);
                    foreach (var project in employee.Projects)
                    {
                        Console.WriteLine("--" + project.Name + " " + project.StartDate + " " + project.EndDate);
                    }
                }
            }
        }

        //08 Address by Town Name
        public static void AddressByTownName()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var address = context.Employees.Select(e => e.Address).OrderByDescending(e => e.Employees.Count).ThenBy(e => e.Town.Name).Distinct().Take(1000);
                foreach (var ad in address)
                {
                    Console.WriteLine(ad.AddressText + ", " + ad.Town.Name + " ");
                }
            }


        }
        //09 Employee with id 147 
        public static void EmployeeWithId147()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var employee147 = context.Employees.Find(147);
                var projectEmp147 = employee147.Projects.OrderBy(p => p.Name);
                Console.WriteLine(employee147.FirstName + " " + employee147.LastName + " " + employee147.JobTitle);
                foreach (var project in projectEmp147)
                {
                    Console.WriteLine(project.Name);
                }

            }
        }
        //10 Departments with more than 5 employees
        public static void DepartmentsWithMoreThen5Employees()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var departments = context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count);

                foreach (Department dep in departments)
                {
                    Console.WriteLine(dep.Name + " " + dep.Manager.FirstName);//napravih promona v Departments mi se kazvache Employee Employee a triabva da e Employee Manager
                    foreach (Employee emp in dep.Employees)
                    {
                        Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.JobTitle);
                    }


                }

            }


        }
        //11. Find Latest 10 Projects
        public static void FindLast10Projects()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var lastTenProjects =
                    context.Projects.OrderByDescending(p => p.StartDate)

                        .Take(10).OrderBy(p => p.Name);
                foreach (Project p in lastTenProjects)
                {
                    Console.WriteLine(p.Name + " " + p.Description + " " + p.StartDate + " " + p.EndDate);

                }
            }
        }
        //12 .Increase Salaries
        public static void IncreaseSalaries()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var employeeWithThisDepartments = context.Employees
                    .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services");
                foreach (var emp in employeeWithThisDepartments)
                {
                    emp.Salary += emp.Salary * 12 / 100;//We need Contex save changes to save the change

                }
                //   context.SaveChanges(); //Need to be out of the foreach
                foreach (var emp in employeeWithThisDepartments)
                {

                    Console.WriteLine(emp.FirstName + " " + emp.LastName + string.Format(" (${0:F6})", emp.Salary));
                }
            }
        }

        //13. Find Employees by First Name Starting with ‘SA’
        public static void NameStartingwithSAseSalaries()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var employeesWithSA = context.Employees.Where(e => e.FirstName.Substring(0, 2) == "SA");
                foreach (var emp in employeesWithSA)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName + " - " + emp.JobTitle + " -" + string.Format(" (${0:F4})", emp.Salary));
                }
            }
        }
        //15.First Letter
        public static void DeleteProjectById()//The way to delete a project
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                var project = context.Projects.Find(2);
                foreach (Employee emp in project.Employees)//First we delete all projects from all employees
                {
                    emp.Projects.Remove(project);
                }
                context.Projects.Remove(project);
                context.SaveChanges();
                var projects = context.Projects.Select(p => p.Name).Take(10);
             
                    Console.WriteLine(project);
                
            }
        }
    }
}
