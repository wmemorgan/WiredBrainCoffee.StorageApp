// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

SqlRepository<Employee> employeeRepository = new(new StorageAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

IWriteRepository<Manager> repo = new SqlRepository<Employee>(new StorageAppDbContext());
repo.Add(new Manager());

ListRepository<Organization> organizationRepository = new();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);

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

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sara" });
    managerRepository.Add(new Manager { FirstName = "Henry" });
    managerRepository.Save();
}

static void AddOrganizations(IRepository<Organization> organizationRepository)
{
    var organizations = new[]
    {
        new Organization { Name = "Pluralsight" },
        new Organization { Name = "Globomatics" }
    };
    AddBatch(organizationRepository, organizations);
}

static void AddBatch(IRepository<Organization> organizationRepository, 
    Organization[] organizations)
{
    foreach (var item in organizations)
    {
        organizationRepository.Add(item);
    }
    organizationRepository.Save();
}