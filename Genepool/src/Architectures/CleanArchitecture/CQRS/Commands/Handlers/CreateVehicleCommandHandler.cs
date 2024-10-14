using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(), // Assign a new GUID
                Make = request.Vehicle.Make,
                Model = request.Vehicle.Model,
                Year = request.Vehicle.Year,
                Color = request.Vehicle.Color,
                OwnerId = request.Vehicle.OwnerId
            };

            var addedVehicle = await _vehicleRepository.AddVehicleAsync(vehicle);
            
            return new VehicleDto
            {
                Id = addedVehicle.Id,
                Make = addedVehicle.Make,
                Model = addedVehicle.Model,
                Year = addedVehicle.Year,
                Color = addedVehicle.Color,
                OwnerId = addedVehicle.OwnerId
            };
        }
    }
}
