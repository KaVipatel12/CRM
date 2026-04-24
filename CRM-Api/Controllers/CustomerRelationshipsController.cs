using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerRelationshipsController : ControllerBase
    {
        private readonly ICustomerRelationshipService _relationshipService;

        public CustomerRelationshipsController(ICustomerRelationshipService relationshipService)
        {
            _relationshipService = relationshipService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _relationshipService.GetByCustomerIdAsync(customerId);
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetRelationshipTypes()
        {
            var result = await _relationshipService.GetRelationshipTypesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRelationshipDto dto)
        {
            var result = await _relationshipService.AddAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _relationshipService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
