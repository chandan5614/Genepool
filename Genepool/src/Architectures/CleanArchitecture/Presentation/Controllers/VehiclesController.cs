using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands;
using Genepool.Architectures.CleanArchitecture.CQRS.Queries;
using MediatR;

namespace Genepool.Architectures.CleanArchitecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetAllVehicles()
        {
            var query = new GetAllVehiclesQuery();
            var vehicles = await _mediator.Send(query);
            return Ok(vehicles); // Return 200 with the list of VehicleDto
        }

        // GET: api/vehicles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicleById(Guid id)
        {
            var query = new GetVehicleByIdQuery(id);
            var vehicleDto = await _mediator.Send(query);
            if (vehicleDto == null)
                return NotFound(); // Return 404 if the vehicle is not found

            return Ok(vehicleDto); // Return 200 with the VehicleDto if found
        }

        // POST: api/vehicles
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            var command = new CreateVehicleCommand(vehicleDto);
            var createdVehicle = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetVehicleById), new { id = createdVehicle.Id }, createdVehicle); // Return 201 with location
        }

        // PUT: api/vehicles/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleDto>> UpdateVehicle(Guid id, [FromBody] VehicleDto vehicleDto)
        {
            if (id != vehicleDto.Id)
                return BadRequest("Vehicle ID mismatch."); // Return 400 if IDs do not match

            var command = new UpdateVehicleCommand(vehicleDto);
            var updatedVehicle = await _mediator.Send(command);
            if (updatedVehicle == null)
                return NotFound(); // Return 404 if the vehicle is not found

            return Ok(updatedVehicle); // Return 200 with the updated VehicleDto
        }

        // DELETE: api/vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var command = new DeleteVehicleCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound(); // Return 404 if the vehicle is not found

            return NoContent(); // Return 204 No Content if deleted successfully
        }
    }
}
