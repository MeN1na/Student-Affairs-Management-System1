namespace BlazorAppServer.UnitOfWork;

public interface IFacultyStaffUnitOfWork : IUnitOfWork<Staff>
{
     Task<Staff?> ReadByDepartment(string Department);
}
