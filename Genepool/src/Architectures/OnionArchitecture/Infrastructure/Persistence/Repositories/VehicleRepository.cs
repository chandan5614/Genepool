using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Genepool.src.Architectures.OnionArchitecture.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
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

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await GetVehicleByIdAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
    }
}