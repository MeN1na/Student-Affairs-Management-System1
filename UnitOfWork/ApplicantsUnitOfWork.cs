namespace BlazorAppServer.UnitOfWork;

public class ApplicantsUnitOfWork : UnitOfWork<Applicant>, IApplicantsUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IApplicantsRepository _applicantsRepository;

    public ApplicantsUnitOfWork(StudentsAffairsDbContext context, IApplicantsRepository applicantsRepository)
           : base(context, applicantsRepository)
    {
        _context = context;
        _applicantsRepository = applicantsRepository;
    }
    public Task<Applicant?> ReadBySecondarySchoolName(string SecondarySchoolName)
    {
        return _applicantsRepository.GetBySecondarySchoolName(SecondarySchoolName);
    }
}

