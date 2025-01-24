namespace BlazorAppServer;

public interface IEmployeesRepository : IRepository<Employee>
{
    Task<Employee?> GetByRole(string Role);
}