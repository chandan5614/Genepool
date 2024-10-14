using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands
{
    public class CreateVehicleCommand : IRequest<VehicleDto>
    {
        public VehicleDto Vehicle { get; set; }

        public CreateVehicleCommand(VehicleDto vehicle)
        {
            Vehicle = vehicle;
        }
    }
}
