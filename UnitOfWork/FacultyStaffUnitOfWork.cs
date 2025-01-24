namespace BlazorAppServer.UnitOfWork;

public class FacultyStaffUnitOfWork : UnitOfWork<Staff>, IFacultyStaffUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IFacultyStaffRepository _facultyStaffRepository;

    public FacultyStaffUnitOfWork(StudentsAffairsDbContext context, IFacultyStaffRepository facultyStaffRepository) 
           : base(context, facultyStaffRepository)
    {
        _context = context;
        _facultyStaffRepository = facultyStaffRepository;
    }
    public Task<Staff?> ReadByDepartment(string Department)
    {
        return _facultyStaffRepository.GetByDepartment(Department);
    }
}

