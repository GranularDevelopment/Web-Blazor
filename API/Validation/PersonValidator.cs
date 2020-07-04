using FluentValidation;

namespace ServiceProtocol.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(i => i.FirstName).NotEmpty().WithMessage("You must enter a name");
            RuleFor(i => i.FirstName).MaximumLength(25).WithMessage("Name cannot be longer than 25 characters");
        }
    }
}
