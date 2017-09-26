using System;
using System.Collections.Generic;
using AutoMapper;
using EmployeeApp.DTOs;
using EmployeeAppModels;
using EmployeeAppModels.DTOs;

namespace EmployeesApp.Client
{
    class Program
    {
        static void Main()
        {
          //01  SimpleMapping();
           ConfigureAutomapping();
            IEnumerable<Employee> managers = CreateManagers();
            IEnumerable<ManagerDTO> managerDtos = Mapper.Map<IEnumerable<Employee>,
                IEnumerable<ManagerDTO>>(managers);

            foreach (ManagerDTO managerDto in managerDtos)
            {
                Console.WriteLine(managerDto.ToString());
            }
        }

        private static IEnumerable<Employee> CreateManagers()
        {
            var managers=new List<Employee>();

           
                var manager = new Employee()
                {
                    FirstName = "Dragan",
                    LastName = "Petkanov",
                    Birthdate = new DateTime(1999, 3, 1),
                    Subordinates = new List<Employee>(),
                    IsOnHoliday = true,
                    Manager = new Employee() {FirstName = "Gosho", LastName = "Ivankov"},
                    Salary = 22m
                };
                var employee1 = new Employee()
                {
                    FirstName = "Stefanaki",
                    LastName = "Frago",
                    Salary = 220m,
                    Manager = manager
                };
                var employee2 = new Employee()
                {
                    FirstName = "Paro",
                    LastName = "Nikodimov",
                    Salary = 22m,
                    Manager = manager
                };
                var employee3 = new Employee()
                {
                    FirstName = "Dido",
                    LastName = "Dano",
                    Salary = 10m,
                    Manager = manager
                };
                manager.Subordinates.Add(employee1);
                manager.Subordinates.Add(employee2);
                manager.Subordinates.Add(employee3);
                managers.Add(manager);
            
          
            return managers;
        }

        static void SimpleMapping()
        {
            ConfigureAutomapping();
            Employee employee = new Employee()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Salary = 45m,
                Birthdate = DateTime.Now,
                Address = "Sofia, krum Popov"
            };

            EmployeeDTO dto = Mapper.Map<EmployeeDTO>(employee);
            Console.WriteLine(dto.FirstName + " " + dto.LastName + " " + dto.Salary);
        }
        public static void ConfigureAutomapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Employee, EmployeeDTO>();
                action.CreateMap<Employee, ManagerDTO>()
                    .ForMember(dto => dto.SuboridatesCount,
                        configExpression => configExpression.MapFrom(e => e.Subordinates.Count));
            });


        }
    }


}

