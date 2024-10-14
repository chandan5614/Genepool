using FluentValidation;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.Validation
{
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        public VehicleValidator()
        {
            RuleFor(vehicle => vehicle.Id)
                .NotEmpty().WithMessage("Vehicle ID must not be empty.");

            RuleFor(vehicle => vehicle.OwnerId)
                .NotEmpty().WithMessage("Owner ID must not be empty.");

            RuleFor(vehicle => vehicle.Make)
                .NotEmpty().WithMessage("Vehicle make must not be empty.")
                .Length(2, 50).WithMessage("Vehicle make must be between 2 and 50 characters.");

            RuleFor(vehicle => vehicle.Model)
                .NotEmpty().WithMessage("Vehicle model must not be empty.")
                .Length(2, 50).WithMessage("Vehicle model must be between 2 and 50 characters.");

            RuleFor(vehicle => vehicle.Year)
                .InclusiveBetween(1886, DateTime.Now.Year).WithMessage("Vehicle year must be between 1886 and the current year.");
        }
    }
}
