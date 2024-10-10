using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Genepool.src.Architectures.OnionArchitecture.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            return await _context.Owners.Include(o => o.Vehicles).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _context.Owners.Include(o => o.Vehicles).ToListAsync();
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

        public async Task DeleteOwnerAsync(int id)
        {
            var owner = await GetOwnerByIdAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
        }
    }
}