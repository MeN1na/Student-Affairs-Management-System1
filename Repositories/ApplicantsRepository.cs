namespace BlazorAppServer;

public class ApplicantsRepository : Repository<Applicant>, IApplicantsRepository
{
    const byte maxAge = 21;
    public ApplicantsRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Applicant?> GetBySecondarySchoolName(string secondarySchoolName)
    {
        Applicant? entityFromDb = await _dbSet.FirstOrDefaultAsync(e => e.SecondarySchoolName != null && 
                                                                                e.SecondarySchoolName.Contains(secondarySchoolName));

        return entityFromDb;
    }

    public override Task Insert(Applicant applicant)
    {
        return base.Insert(applicant); 
    }
}