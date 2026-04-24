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
    public class DynamicFieldMastersController : ControllerBase
    {
        private readonly IDynamicFieldService _dynamicFieldService;

        public DynamicFieldMastersController(IDynamicFieldService dynamicFieldService)
        {
            _dynamicFieldService = dynamicFieldService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dynamicFieldService.GetMastersAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDynamicFieldMasterDto dto)
        {
            var result = await _dynamicFieldService.AddMasterAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDynamicFieldMasterDto dto)
        {
            var success = await _dynamicFieldService.UpdateMasterAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _dynamicFieldService.DeleteMasterAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
