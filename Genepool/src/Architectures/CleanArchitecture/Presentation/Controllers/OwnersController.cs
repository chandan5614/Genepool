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
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/owners/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetOwnerById(Guid id)
        {
            var query = new GetOwnerByIdQuery(id);
            var ownerDto = await _mediator.Send(query);
            if (ownerDto == null)
                return NotFound(); // Return 404 if the owner is not found

            return Ok(ownerDto); // Return 200 with the OwnerDto if found
        }

        // POST: api/owners
        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreateOwner([FromBody] OwnerDto ownerDto)
        {
            var command = new CreateOwnerCommand(ownerDto);
            var createdOwner = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOwnerById), new { id = createdOwner.Id }, createdOwner); // Return 201 with location
        }

    }
}
