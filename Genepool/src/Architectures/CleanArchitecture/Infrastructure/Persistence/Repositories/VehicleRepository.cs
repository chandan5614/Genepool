using Genepool.Architectures.CleanArchitecture.Core.Entities;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genepool.Architectures.OnionArchitecture.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Include(v => v.Owner) // Include the Owner for detailed data
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.Owner) // Include the Owner for detailed data
                .FirstOrDefaultAsync(v => v.Id == vehicleId);
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle; // Returning the added vehicle
        }

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle; // Returning the updated vehicle
        }

        public async Task<bool> DeleteVehicleAsync(Guid vehicleId)
        {
            var vehicle = await GetVehicleByIdAsync(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return true; // Vehicle deleted successfully
            }
            return false; // Vehicle not found
        }
    }
}
