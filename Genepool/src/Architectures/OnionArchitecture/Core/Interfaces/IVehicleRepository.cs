using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;

namespace Genepool.src.Architectures.OnionArchitecture.Core.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}