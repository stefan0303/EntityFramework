
using System;
using SoftUni_data;


class Program
{

    static void Main()
    {
        string command = Console.ReadLine(); //Choose number of command
        switch (command)
        {
            case "3":
                OperationsWithData.EmployeesFullInformation(); //03
                break;
            case "4":
                OperationsWithData.EmployeeswithSalaryOver50000();//04
                break;
            case "5":
                OperationsWithData.EmployeesfromSeattle();//05
                break;
            case "6":
                OperationsWithData.AddingNewAddressUpdatingEmployee();//06
                break;
            case "7":
                OperationsWithData.FindEmployeesPeriod();//07
                break;
            case "8":
                OperationsWithData.AddressByTownName();//08
                break;
            case "9":
                OperationsWithData.EmployeeWithId147();//09
                break;
            case "10":
                OperationsWithData.DepartmentsWithMoreThen5Employees(); //10
                break;
            case "11":
                OperationsWithData.FindLast10Projects();//11
                break;
            case "12":
                OperationsWithData.IncreaseSalaries();//12
                break;
            case "13":
                OperationsWithData.NameStartingwithSAseSalaries();//13
                break;
            case "15":
                OperationsWithData.DeleteProjectById();//15
                break;
        }
    }
}


