namespace BlazorAppServer;

public class ApplicantValidatorcs : AbstractValidator<Applicant>
{
    public ApplicantValidatorcs()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(s => s.Age).
            NotEmpty().WithMessage("Age is required");

        RuleFor(s => s.Mobile)
            .NotEmpty().WithMessage("Mobile is required");

        RuleFor(s => s.SecondarySchoolName)
            .NotEmpty().WithMessage("Department is required");
    }
}
