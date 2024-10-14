using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.Architectures.OnionArchitecture.Core.Entities;

namespace Genepool.Architectures.OnionArchitecture.Core.Interfaces
{
    public interface IVehicleService
    {
        // Retrieve all vehicles asynchronously
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();

        // Retrieve a specific vehicle by ID asynchronously
        Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId);

        // Add a new vehicle asynchronously
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);

        // Update an existing vehicle asynchronously
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);

        // Delete a vehicle by ID asynchronously
        Task<bool> DeleteVehicleAsync(Guid vehicleId);
    }
}
