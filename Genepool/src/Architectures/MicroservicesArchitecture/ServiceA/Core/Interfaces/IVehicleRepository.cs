using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId);
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(Guid vehicleId);
        Task<IEnumerable<Vehicle>> GetVehiclesByOwnerIdAsync(Guid ownerId);
    }
}
