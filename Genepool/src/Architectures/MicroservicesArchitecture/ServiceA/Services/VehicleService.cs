using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Dtos;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Entities;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Core.Interfaces;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto?> GetVehicleByIdAsync(Guid vehicleId)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
            return vehicle == null ? null : new VehicleDto
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Year = vehicle.Year,
                OwnerId = vehicle.OwnerId
            };
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            var vehicleDtos = new List<VehicleDto>();

            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleDto
                {
                    Id = vehicle.Id,
                    Model = vehicle.Model,
                    Make = vehicle.Make,
                    Year = vehicle.Year,
                    OwnerId = vehicle.OwnerId
                });
            }

            return vehicleDtos;
        }

        public async Task AddVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Model = vehicleDto.Model,
                Make = vehicleDto.Make,
                Year = vehicleDto.Year,
                OwnerId = vehicleDto.OwnerId
            };

            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Id = vehicleDto.Id,
                Model = vehicleDto.Model,
                Make = vehicleDto.Make,
                Year = vehicleDto.Year,
                OwnerId = vehicleDto.OwnerId
            };

            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(Guid vehicleId)
        {
            await _vehicleRepository.DeleteVehicleAsync(vehicleId);
        }

        public async Task<IEnumerable<VehicleDto>> GetVehiclesByOwnerIdAsync(Guid ownerId)
        {
            var vehicles = await _vehicleRepository.GetVehiclesByOwnerIdAsync(ownerId);
            var vehicleDtos = new List<VehicleDto>();

            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleDto
                {
                    Id = vehicle.Id,
                    Model = vehicle.Model,
                    Make = vehicle.Make,
                    Year = vehicle.Year,
                    OwnerId = vehicle.OwnerId
                });
            }

            return vehicleDtos;
        }
    }
}
