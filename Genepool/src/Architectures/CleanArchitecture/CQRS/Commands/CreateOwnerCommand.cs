using MediatR;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;

namespace Genepool.Architectures.CleanArchitecture.CQRS.Commands
{
    public class CreateOwnerCommand : IRequest<OwnerDto>
    {
        public OwnerDto Owner { get; set; }

        public CreateOwnerCommand(OwnerDto owner)
        {
            Owner = owner;
        }
    }
}
