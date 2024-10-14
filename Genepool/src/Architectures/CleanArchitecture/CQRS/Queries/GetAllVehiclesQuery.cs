using MediatR;
using System.Collections.Generic;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries
{
    public class GetAllVehiclesQuery : IRequest<IEnumerable<VehicleDto>>
    {
    }
}
