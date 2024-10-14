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
    [Route("api/clean/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetAllOwners()
        {
            var owners = await _ownerRepository.GetAllOwnersAsync();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwnerById(int id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult<Owner>> CreateOwner(Owner owner)
        {
            await _ownerRepository.AddOwnerAsync(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, owner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }
            await _ownerRepository.UpdateOwnerAsync(owner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            await _ownerRepository.DeleteOwnerAsync(id);
            return NoContent();
        }
    }
}