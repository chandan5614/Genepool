using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Queries.Handlers
{
    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerDto>
    {
        private readonly IOwnerRepository _ownerRepository;

        public GetOwnerByIdQueryHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerDto> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the owner by ID using the repository
            var owner = await _ownerRepository.GetOwnerByIdAsync(request.OwnerId);
            // Convert Owner entity to OwnerDto
            return new OwnerDto 
            { 
                Id = owner.Id, 
                Name = owner.Name, 
                // Add other properties as needed
            };
        }
    }
}
