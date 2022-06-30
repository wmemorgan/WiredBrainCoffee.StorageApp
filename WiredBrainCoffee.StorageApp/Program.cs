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
    var employees = new[]
    {
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" }
    };
    employeeRepository.AddBatch(employees);
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    var saraManager = new Manager { FirstName = "Sara" };
    var saraManagerCopy = saraManager.Copy();
    managerRepository.Add(saraManager);

    if(saraManagerCopy is not null)
    {
        saraManagerCopy.FirstName += "_Copy";
        managerRepository.Add(saraManagerCopy);
    }

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
    organizationRepository.AddBatch(organizations);
}