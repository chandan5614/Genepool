using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Exceptions;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;

namespace Genepool.src.Architectures.OnionArchitecture.Application.Services
{
    public class OwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                throw new NotFoundException($"Owner with id {id} not found.");
            }
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllOwnersAsync();
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            if (string.IsNullOrWhiteSpace(owner.Name))
            {
                throw new BadRequestException("Owner name cannot be empty.");
            }
            await _ownerRepository.AddOwnerAsync(owner);
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            await _ownerRepository.UpdateOwnerAsync(owner);
        }

        public async Task DeleteOwnerAsync(int id)
        {
            await _ownerRepository.DeleteOwnerAsync(id);
        }
    }
}