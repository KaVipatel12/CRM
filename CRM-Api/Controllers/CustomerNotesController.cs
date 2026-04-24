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
    public class CustomerNotesController : ControllerBase
    {
        private readonly ICustomerNoteService _customerNoteService;

        public CustomerNotesController(ICustomerNoteService customerNoteService)
        {
            _customerNoteService = customerNoteService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _customerNoteService.GetByCustomerIdAsync(customerId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerNoteDto dto)
        {
            var result = await _customerNoteService.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCustomer), new { customerId = result.CustomerId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerNoteDto dto)
        {
            var success = await _customerNoteService.UpdateAsync(dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _customerNoteService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
