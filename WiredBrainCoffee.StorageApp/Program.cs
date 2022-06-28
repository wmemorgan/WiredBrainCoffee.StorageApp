// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

GenericRepository<Employee> employeeRepository = new();
AddEmployees(employeeRepository);
GetEmployeeById(employeeRepository);

void GetEmployeeById(GenericRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
}

GenericRepository<Organization> organizationRepository = new();

AddOrganizations(organizationRepository);

Console.ReadLine();

static void AddEmployees(GenericRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Anna" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });
    employeeRepository.Save();
}

static void AddOrganizations(GenericRepository<Organization> organizationRepository)
{
    organizationRepository.Add(new Organization { Name = "Pluralsight" });
    organizationRepository.Add(new Organization { Name = "Globomatics" });
    organizationRepository.Save();
}