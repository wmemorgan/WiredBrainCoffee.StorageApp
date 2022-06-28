// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Repositories;

EmployeeRepository employeeRepository = new();
employeeRepository.Add(new WiredBrainCoffee.StorageApp.Entities.Employee { FirstName = "Julia" });
employeeRepository.Add(new WiredBrainCoffee.StorageApp.Entities.Employee { FirstName = "Anna" });
employeeRepository.Add(new WiredBrainCoffee.StorageApp.Entities.Employee { FirstName = "Thomas" });
employeeRepository.Save();

Console.ReadLine();

