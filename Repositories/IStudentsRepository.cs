namespace BlazorAppServer;

public interface IStudentsRepository : IRepository<Student>
{
    Task<Student?> GetByScholarShipType(string scholarShipType);
}
