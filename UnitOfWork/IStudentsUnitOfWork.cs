namespace BlazorAppServer.UnitOfWork;

public interface IStudentsUnitOfWork : IUnitOfWork<Student>
{
    Task<Student?> ReadByScholarShipType(string scholarShipType);
}