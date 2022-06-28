// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

GenericRepositoryWithRemove<Employee> employeeRepository = new();
employeeRepository.Add(new Employee { FirstName = "Julia" });
employeeRepository.Add(new Employee { FirstName = "Anna" });
employeeRepository.Add(new Employee { FirstName = "Thomas" });
employeeRepository.Save();

GenericRepositoryWithRemove<Organization> organizationRepository = new();
organizationRepository.Add(new Organization { Name = "Pluralsight" });
organizationRepository.Add(new Organization { Name = "Globomatics" });
organizationRepository.Save();

Console.ReadLine();

