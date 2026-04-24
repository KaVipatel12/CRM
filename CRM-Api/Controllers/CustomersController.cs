using CRM_Api.DTOs;
using CRM_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Linq;
using CRM_Api.Services.Interfaces;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserContext _userContext;

        public CustomersController(ICustomerService customerService, IUserContext userContext)
        {
            _customerService = customerService;
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerPagedResponseDto>> GetCustomers([FromQuery] CustomerListFilter filter)
        {
            var pagedResult = await _customerService.GetHistoryListAsync(filter);
            return Ok(pagedResult);
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<CustomerStatisticsDto>> GetStatistics()
        {
            var stats = await _customerService.GetStatisticsAsync();
            return Ok(stats);
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
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

        [HttpPost("{id:int}/verify")]
        [Authorize(Roles = "Checker")]
        public async Task<IActionResult> VerifyCustomer(int id)
        {
            var userId = _userContext.UserId;
            
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _customerService.VerifyCustomerAsync(id, userId.Value);
            if (!result)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPost("{id:int}/change-type")]
        public async Task<IActionResult> ChangeCustomerType(int id, [FromBody] ChangeTypeRequestDto req)
        {
            if (req == null || req.NewClientType <= 0) 
                return BadRequest("Invalid client type provided.");

            var result = await _customerService.MigrateCustomerTypeAsync(id, req.NewClientType);
            if (!result)
            {
                return NotFound("Customer not found or migration failed.");
            }
            return Ok(true);
        }

        // --- Service Portfolio Endpoints ---

        [HttpGet("services/masters")]
        public async Task<ActionResult<IEnumerable<ServiceMasterDto>>> GetServiceMasters()
        {
            var masters = await _customerService.GetServiceMastersAsync();
            return Ok(masters);
        }

        [HttpGet("{id:int}/services")]
        public async Task<ActionResult<IEnumerable<CustomerServiceDto>>> GetCustomerServices(int id)
        {
            var services = await _customerService.GetCustomerServicesAsync(id);
            return Ok(services);
        }

        [HttpPost("services")]
        public async Task<IActionResult> UpsertCustomerService([FromBody] CustomerServiceDto dto)
        {
            var result = await _customerService.UpsertCustomerServiceAsync(dto);
            return Ok(result);
        }

        [HttpDelete("services/{id:int}")]
        public async Task<IActionResult> DeleteCustomerService(int id)
        {
            var result = await _customerService.DeleteCustomerServiceAsync(id);
            return Ok(result);
        }

        [HttpGet("upcoming-birthdays")]
        public async Task<ActionResult<IEnumerable<UpcomingBirthdayDto>>> GetUpcomingBirthdays([FromQuery] bool forceRefresh = false)
        {
            var birthdays = await _customerService.GetUpcomingBirthdaysAsync(forceRefresh);
            return Ok(birthdays);
        }
    }
}
