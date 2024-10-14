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
    public class OwnersController : ControllerBase
    {
        private readonly OwnerService _ownerService;

        public OwnersController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _ownerService.GetAllOwnersAsync();
            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] OwnerDto ownerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ownerService.AddOwnerAsync(ownerDto);
            return CreatedAtAction(nameof(GetOwnerById), new { id = ownerDto.Id }, ownerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerDto ownerDto)
        {
            if (id != ownerDto.Id)
            {
                return BadRequest();
            }

            await _ownerService.UpdateOwnerAsync(ownerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            await _ownerService.DeleteOwnerAsync(id);
            return NoContent();
        }
    }
}
