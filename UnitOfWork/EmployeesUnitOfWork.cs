namespace BlazorAppServer.UnitOfWork;

public class EmployeesUnitOfWork : UnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesUnitOfWork(StudentsAffairsDbContext context, IEmployeesRepository employeeRepository)
           : base(context, employeeRepository)
    {
        _context = context;
        _employeesRepository = employeeRepository;
    }
    public Task<Employee?> ReadByRole(string Role)
    {
        return _employeesRepository.GetByRole(Role);
    }
}
  
