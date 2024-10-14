using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Dtos;
using Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Genepool.src.Architectures.MicroservicesArchitecture.ServiceA.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(Guid id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _vehicleService.AddVehicleAsync(vehicleDto);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicleDto.Id }, vehicleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] VehicleDto vehicleDto)
        {
            if (id != vehicleDto.Id)
            {
                return BadRequest();
            }

            await _vehicleService.UpdateVehicleAsync(vehicleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetVehiclesByOwnerId(Guid ownerId)
        {
            var vehicles = await _vehicleService.GetVehiclesByOwnerIdAsync(ownerId);
            return Ok(vehicles);
        }
    }
}
