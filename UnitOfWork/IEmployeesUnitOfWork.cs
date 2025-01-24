namespace BlazorAppServer.UnitOfWork;

public interface IEmployeesUnitOfWork : IUnitOfWork<Employee>
{
    Task<Employee?> ReadByRole(string Role);
}

