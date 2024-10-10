using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;

namespace Genepool.src.Architectures.OnionArchitecture.Core.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> GetOwnerByIdAsync(int id);
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task AddOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(int id);
    }
}