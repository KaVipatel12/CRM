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
    public class DynamicFieldValuesController : ControllerBase
    {
        private readonly IDynamicFieldService _dynamicFieldService;

        public DynamicFieldValuesController(IDynamicFieldService dynamicFieldService)
        {
            _dynamicFieldService = dynamicFieldService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var result = await _dynamicFieldService.GetValuesByCustomerIdAsync(customerId);
            return Ok(result);
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> Upsert(int customerId, [FromBody] IEnumerable<UpsertDynamicFieldValueDto> values)
        {
            var success = await _dynamicFieldService.UpsertValuesAsync(customerId, values);
            if (!success) return BadRequest("Could not save dynamic field values.");
            return Ok(new { message = "Dynamic field values saved successfully." });
        }
    }
}
