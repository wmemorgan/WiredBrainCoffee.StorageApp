// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

SqlRepository<Employee> employeeRepository = new(new StorageAppDbContext());
AddEmployees(employeeRepository);
GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

ListRepository<Organization> organizationRepository = new();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);

IReadRepository<object> repo = new ListRepository<Organization>();

Console.ReadLine();


void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    IEnumerable<IEntity> items = repository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
}

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Anna" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });
    employeeRepository.Save();
}

static void AddOrganizations(IRepository<Organization> organizationRepository)
{
    organizationRepository.Add(new Organization { Name = "Pluralsight" });
    organizationRepository.Add(new Organization { Name = "Globomatics" });
    organizationRepository.Save();
}