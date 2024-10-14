using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Interfaces;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ServiceADbContext _context;

        public OwnerRepository(ServiceADbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await _context.Owners
                .FirstOrDefaultAsync(owner => owner.Id == ownerId);
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOwnerAsync(Guid ownerId)
        {
            var owner = await GetOwnerByIdAsync(ownerId);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
