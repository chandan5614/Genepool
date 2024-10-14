using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using MediatR;
using System;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries
{
    public class GetVehicleByIdQuery : IRequest<VehicleDto>
    {
        public Guid VehicleId { get; set; }

        public GetVehicleByIdQuery(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
