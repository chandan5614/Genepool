using FluentValidation;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.Validation
{
    public class OwnerValidator : AbstractValidator<OwnerDto>
    {
        public OwnerValidator()
        {
            RuleFor(owner => owner.Id)
                .NotEmpty().WithMessage("Owner ID must not be empty.");

            RuleFor(owner => owner.Name)
                .NotEmpty().WithMessage("Owner name must not be empty.")
                .Length(2, 100).WithMessage("Owner name must be between 2 and 100 characters.");

            RuleFor(owner => owner.Email)
                .NotEmpty().WithMessage("Email must not be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(owner => owner.PhoneNumber)
                .NotEmpty().WithMessage("Phone number must not be empty.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be a 10-digit number.");
        }
    }
}
