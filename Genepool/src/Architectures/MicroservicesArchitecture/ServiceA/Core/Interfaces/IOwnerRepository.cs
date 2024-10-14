using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task AddOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(Guid ownerId);
    }
}
