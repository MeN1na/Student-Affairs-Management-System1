namespace BlazorAppServer.UnitOfWork;

public interface IApplicantsUnitOfWork : IUnitOfWork<Applicant>
{
    Task<Applicant?> ReadBySecondarySchoolName(string SecondarySchoolName);
}



