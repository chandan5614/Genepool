using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands
{
    public class UpdateVehicleCommand : IRequest<VehicleDto>
    {
        public VehicleDto Vehicle { get; set; }

        public UpdateVehicleCommand(VehicleDto vehicle)
        {
            Vehicle = vehicle;
        }
    }
}
