using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Exceptions;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;

namespace Genepool.src.Architectures.OnionArchitecture.Application.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                throw new NotFoundException($"Vehicle with id {id} not found.");
            }
            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Model) || string.IsNullOrWhiteSpace(vehicle.LicensePlate))
            {
                throw new BadRequestException("Vehicle model and license plate cannot be empty.");
            }
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
        }
    }
}