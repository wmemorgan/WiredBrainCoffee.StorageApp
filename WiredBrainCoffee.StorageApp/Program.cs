// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

GenericRepository<Employee> employeeRepository = new();
employeeRepository.Add(new Employee { FirstName = "Julia" });
employeeRepository.Add(new Employee { FirstName = "Anna" });
employeeRepository.Add(new Employee { FirstName = "Thomas" });
employeeRepository.Save();

GenericRepository<Organization> organizationRepository = new();
organizationRepository.Add(new Organization { Name = "Pluralsight" });
organizationRepository.Add(new Organization { Name = "Globomatics" });
organizationRepository.Save();

Console.ReadLine();

