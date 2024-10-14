using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.DeleteVehicleAsync(request.VehicleId);
        }
    }
}
