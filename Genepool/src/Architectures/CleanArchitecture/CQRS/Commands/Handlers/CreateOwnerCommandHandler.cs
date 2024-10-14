using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, OwnerDto>
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerDto> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            // Convert OwnerDto to Owner entity
            var ownerEntity = new Owner
            {
                // Assuming Owner entity has properties Id, Name, etc.
                Name = request.Owner.Name,
                // Add other properties as needed
            };

            // Add the new owner using the repository
            var addedOwner = await _ownerRepository.AddOwnerAsync(ownerEntity);

            // Convert the added Owner entity to OwnerDto
            return new OwnerDto 
            { 
                Id = addedOwner.Id, 
                Name = addedOwner.Name,
                // Add other properties as needed
            };
        }
    }
}
