namespace BlazorAppServer.UnitOfWork;

public class StudentsUnitOfWork : UnitOfWork<Student> , IStudentsUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IStudentsRepository _studentsRepository;
    public StudentsUnitOfWork(StudentsAffairsDbContext context, IStudentsRepository studentsRepository) 
            : base (context, studentsRepository)
    {
        _context = context;
        _studentsRepository = studentsRepository;
    }

    public Task<Student?> ReadByScholarShipType(string scholarShipType)
    {
        return _studentsRepository.GetByScholarShipType(scholarShipType);
    }
}

