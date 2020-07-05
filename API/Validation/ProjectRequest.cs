using FluentValidation;

namespace ServiceProtocol.Validation
{
    public class ProjectRequestValidator : AbstractValidator<ProjectRequest>
    {
        public ProjectRequestValidator()
        {
            RuleFor(i => i.Person.FirstName).NotEmpty().WithMessage("You must enter a name");
            RuleFor(i => i.Person.FirstName).MaximumLength(25).WithMessage("Name cannot be longer than 25 characters");
        }
    }
}
