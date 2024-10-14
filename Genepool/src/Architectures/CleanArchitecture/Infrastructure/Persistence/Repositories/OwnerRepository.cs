using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.Architectures.CleanArchitecture.Core.Entities;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Infrastructure.Configurations;

namespace Genepool.Architectures.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await Task.FromResult(_context.Owners.ToList());
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await Task.FromResult(_context.Owners.FirstOrDefault(o => o.Id == ownerId));
        }

        public async Task<Owner> AddOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<bool> DeleteOwnerAsync(Guid ownerId)
        {
            var owner = await GetOwnerByIdAsync(ownerId);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
