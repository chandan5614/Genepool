using MediatR;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands
{
    public class DeleteVehicleCommand : IRequest<bool>
    {
        public Guid VehicleId { get; set; }

        public DeleteVehicleCommand(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
