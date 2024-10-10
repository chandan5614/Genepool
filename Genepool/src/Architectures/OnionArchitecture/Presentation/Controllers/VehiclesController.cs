using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Genepool.src.Architectures.OnionArchitecture.Core.Entities;
using Genepool.src.Architectures.OnionArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Genepool.src.Architectures.OnionArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            await _vehicleRepository.UpdateVehicleAsync(vehicle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleRepository.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}