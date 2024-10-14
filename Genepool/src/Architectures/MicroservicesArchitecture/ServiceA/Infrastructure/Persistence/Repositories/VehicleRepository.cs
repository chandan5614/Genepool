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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ServiceADbContext _context;

        public VehicleRepository(ServiceADbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(vehicle => vehicle.Id == vehicleId);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(Guid vehicleId)
        {
            var vehicle = await GetVehicleByIdAsync(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByOwnerIdAsync(Guid ownerId)
        {
            return await _context.Vehicles
                .Where(vehicle => vehicle.OwnerId == ownerId)
                .ToListAsync();
        }
    }
}
