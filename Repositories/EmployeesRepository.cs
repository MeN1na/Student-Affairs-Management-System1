namespace BlazorAppServer;

public class EmployeesRepository : Repository<Employee>, IEmployeesRepository
{
    public EmployeesRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Employee?> GetByRole(string Role)
    {
        Employee? entityFromDb = await _dbSet.FirstOrDefaultAsync(e => e.Role != null &&
                                                                            e.Role.Contains(Role));

        return entityFromDb;
    }

}
