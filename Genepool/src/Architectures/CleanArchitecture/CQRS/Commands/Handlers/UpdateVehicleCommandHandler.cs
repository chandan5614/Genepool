using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                Id = request.Vehicle.Id,
                Make = request.Vehicle.Make,
                Model = request.Vehicle.Model,
                Year = request.Vehicle.Year,
                Color = request.Vehicle.Color,
                OwnerId = request.Vehicle.OwnerId
            };

            var updatedVehicle = await _vehicleRepository.UpdateVehicleAsync(vehicle);
            
            return new VehicleDto
            {
                Id = updatedVehicle.Id,
                Make = updatedVehicle.Make,
                Model = updatedVehicle.Model,
                Year = updatedVehicle.Year,
                Color = updatedVehicle.Color,
                OwnerId = updatedVehicle.OwnerId
            };
        }
    }
}
