using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.Architectures.OnionArchitecture.Core.Entities;
using Genepool.Architectures.OnionArchitecture.Core.Interfaces;

namespace Genepool.Architectures.OnionArchitecture.Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _ownerRepository.GetAllOwnersAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await _ownerRepository.GetOwnerByIdAsync(ownerId);
        }

        public async Task<Owner> AddOwnerAsync(Owner owner)
        {
            return await _ownerRepository.AddOwnerAsync(owner);
        }

        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            return await _ownerRepository.UpdateOwnerAsync(owner);
        }

        public async Task<bool> DeleteOwnerAsync(Guid ownerId)
        {
            return await _ownerRepository.DeleteOwnerAsync(ownerId);
        }
    }
}
