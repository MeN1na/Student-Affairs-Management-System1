namespace BlazorAppServer;

public class FacultyStaffRepository : Repository<Staff>, IFacultyStaffRepository
{
    public FacultyStaffRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Staff?> GetByDepartment(string Department)
    {
        Staff? entityFromDb = await _dbSet.FirstOrDefaultAsync(e => e.Department != null &&
                                                                            e.Department.Contains(Department));

        return entityFromDb;
    }
}
