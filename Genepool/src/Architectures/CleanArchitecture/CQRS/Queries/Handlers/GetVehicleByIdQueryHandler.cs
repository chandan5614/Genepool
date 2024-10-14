using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries.Handlers
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId);
            return new VehicleDto
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                OwnerId = vehicle.OwnerId
            };
        }
    }
}
