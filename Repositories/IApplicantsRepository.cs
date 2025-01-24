namespace BlazorAppServer;

public interface IApplicantsRepository : IRepository<Applicant>
{
    Task<Applicant?> GetBySecondarySchoolName(string secondarySchoolName);
}
 