using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using MediatR;
using System;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries
{
    public class GetOwnerByIdQuery : IRequest<OwnerDto>
    {
        public Guid OwnerId { get; }

        public GetOwnerByIdQuery(Guid ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
