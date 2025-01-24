namespace BlazorAppServer;

public class FacultyStaffValidator : AbstractValidator<Staff>
{
    public FacultyStaffValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(s => s.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required."); ;

        RuleFor(s => s.Age).
            NotEmpty().WithMessage("Age is required");

        RuleFor(s => s.Mobile)
            .NotEmpty().WithMessage("Mobile is required");

        RuleFor(s => s.Department)
            .NotEmpty().WithMessage("Department is required");
    }
}
