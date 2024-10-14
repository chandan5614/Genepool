using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Dtos;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Interfaces;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Services
{
    public class OwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerDto?> GetOwnerByIdAsync(Guid ownerId)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(ownerId);
            return owner == null ? null : new OwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Email = owner.Email
            };
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
        {
            var owners = await _ownerRepository.GetAllOwnersAsync();
            var ownerDtos = new List<OwnerDto>();

            foreach (var owner in owners)
            {
                ownerDtos.Add(new OwnerDto
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    Email = owner.Email
                });
            }

            return ownerDtos;
        }

        public async Task AddOwnerAsync(OwnerDto ownerDto)
        {
            var owner = new Owner
            {
                Id = Guid.NewGuid(),
                Name = ownerDto.Name,
                Email = ownerDto.Email
            };

            await _ownerRepository.AddOwnerAsync(owner);
        }

        public async Task UpdateOwnerAsync(OwnerDto ownerDto)
        {
            var owner = new Owner
            {
                Id = ownerDto.Id,
                Name = ownerDto.Name,
                Email = ownerDto.Email
            };

            await _ownerRepository.UpdateOwnerAsync(owner);
        }

        public async Task DeleteOwnerAsync(Guid ownerId)
        {
            await _ownerRepository.DeleteOwnerAsync(ownerId);
        }
    }
}
