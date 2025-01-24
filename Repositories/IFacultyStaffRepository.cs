namespace BlazorAppServer;

public interface IFacultyStaffRepository : IRepository<Staff>
{
    Task<Staff?> GetByDepartment(string Department);
}
