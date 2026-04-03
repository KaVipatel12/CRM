using CRM_Api.DTOs;
using CRM_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerListDto>>> GetCustomers([FromQuery] CustomerListFilter filter)
        {
            var customers = await _customerService.GetHistoryListAsync(filter);
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDetailsDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer(CustomerSaveDto dto)
        {
            var id = await _customerService.CreateCustomerAsync(dto);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerSaveDto dto)
        {
            var result = await _customerService.UpdateCustomerAsync(id, dto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("GetIncrementCodeByType")]
        public async Task<IActionResult> GetIncrementCodeByType([FromQuery] int contactType)
        {
            if (contactType == 0)
                return BadRequest();
                
            int code = await _customerService.GetIncrementCodeByTypeAsync(contactType);
            return Ok(code);
        }

        [HttpGet("CheckDuplicateCode/{code}")]
        public async Task<IActionResult> CheckDuplicateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest();

            bool isDuplicate = await _customerService.CheckDuplicateCodeAsync(code);
            return Ok(isDuplicate);
        }
    }
}
