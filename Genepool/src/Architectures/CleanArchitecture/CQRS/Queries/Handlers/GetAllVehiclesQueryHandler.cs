using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries.Handlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<VehicleDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            var vehicleDtos = new List<VehicleDto>();

            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleDto
                {
                    Id = vehicle.Id,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    Color = vehicle.Color,
                    OwnerId = vehicle.OwnerId
                });
            }

            return vehicleDtos;
        }
    }
}
