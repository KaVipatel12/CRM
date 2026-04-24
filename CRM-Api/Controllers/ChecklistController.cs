using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChecklistController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/checklist/5
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ChecklistItemDto>>> GetChecklistForCustomer(int customerId)
        {
            // 1. Get the customer to know their ClientType
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
                return NotFound("Customer not found.");

            // To map the ClientType integer to the string name (Company, Trust, etc.)
            var customerType = await _context.CustomerTypes.FindAsync(customer.ClientType);
            string typeName = customerType?.CustomerTypeNM ?? "Unknown";

            // 2. Fetch all ACTIVE Master tasks
            var allMasterTasks = await _context.ChecklistMasters
                .Where(m => m.IsActive)
                .OrderBy(m => m.Category)
                .ThenBy(m => m.SortOrder)
                .ToListAsync();

            // Filter master tasks by ApplicableClientType if specified (e.g. "All" or contains typeName)
            var applicableTasks = allMasterTasks.Where(m => 
                string.IsNullOrEmpty(m.ApplicableClientType) || 
                m.ApplicableClientType.Contains("All", StringComparison.OrdinalIgnoreCase) || 
                m.ApplicableClientType.Contains(typeName, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            // 3. Fetch the customer's actual checklist statuses
            var customerStatuses = await _context.CustomerChecklistStatuses
                .Include(s => s.CompletedByUser)
                .Where(s => s.CustomerID == customerId)
                .ToListAsync();

            // 4. Merge them into the DTO
            var result = new List<ChecklistItemDto>();

            foreach (var task in applicableTasks)
            {
                var status = customerStatuses.FirstOrDefault(s => s.ChecklistMasterID == task.Id);

                result.Add(new ChecklistItemDto
                {
                    ChecklistMasterId = task.Id,
                    TaskName = task.TaskName,
                    Description = task.Description,
                    Category = task.Category,
                    SortOrder = task.SortOrder,
                    
                    StatusId = status?.Id,
                    IsCompleted = status?.IsCompleted ?? false,
                    CompletedDT = status?.CompletedDT,
                    CompletedByUserID = status?.CompletedByUserID,
                    CompletedByUserName = status?.CompletedByUser != null 
                        ? $"{status.CompletedByUser.FirstName} {status.CompletedByUser.LastName}".Trim() 
                        : null,
                    Notes = status?.Notes
                });
            }

            return Ok(result);
        }

        // POST: api/checklist/toggle
        [HttpPost("toggle")]
        public async Task<ActionResult> ToggleChecklistStatus([FromBody] ToggleChecklistDto dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("id");
            if (!int.TryParse(userIdStr, out int currentUserId))
            {
                return Unauthorized();
            }

            // Find existing status
            var status = await _context.CustomerChecklistStatuses
                .FirstOrDefaultAsync(s => s.CustomerID == dto.CustomerId && s.ChecklistMasterID == dto.ChecklistMasterId);

            if (status == null)
            {
                // Create new
                status = new CustomerChecklistStatus
                {
                    CustomerID = dto.CustomerId,
                    ChecklistMasterID = dto.ChecklistMasterId,
                    IsCompleted = dto.IsCompleted,
                    Notes = dto.Notes
                };
                
                if (dto.IsCompleted)
                {
                    status.CompletedByUserID = currentUserId;
                    status.CompletedDT = DateTime.Now;
                }

                _context.CustomerChecklistStatuses.Add(status);
            }
            else
            {
                // Update existing
                status.IsCompleted = dto.IsCompleted;
                status.Notes = dto.Notes;

                if (dto.IsCompleted)
                {
                    // If newly completed, record who did it and when
                    status.CompletedByUserID = currentUserId;
                    status.CompletedDT = DateTime.Now;
                }
                else
                {
                    // If unchecked, clear the completed tracking
                    status.CompletedByUserID = null;
                    status.CompletedDT = null;
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
    }
}
