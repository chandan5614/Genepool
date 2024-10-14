using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.Core.Interfaces
{
    public interface IOwnerRepository
    {
        // Retrieve all owners asynchronously
        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        // Retrieve a specific owner by ID asynchronously
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);

        // Add a new owner asynchronously
        Task<Owner> AddOwnerAsync(Owner owner);

        // Update an existing owner asynchronously
        Task<Owner> UpdateOwnerAsync(Owner owner);

        // Delete an owner by ID asynchronously
        Task<bool> DeleteOwnerAsync(Guid ownerId);
    }
}
