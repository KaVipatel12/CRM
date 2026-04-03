using CRM_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            // Join Actions with Details, TypeMaster, Customer, and Status
            var jobs = await _context.Actions
                .Include(a => a.Detail)
                    .ThenInclude(d => d.Type)
                .Include(a => a.Detail)
                    // .ThenInclude(d => d.Customer) // Add this if Customer relationship is defined in Detail
                .OrderByDescending(a => a.UpdateDateTime)
                .Select(a => new
                {
                    a.ID,
                    Code = a.Detail.Type.ShortCode,
                    Caption = a.Detail.Caption,
                    // Name = a.Detail.Customer.Name, // This depends on the specific relationship structure
                    DueDate = a.DueDate,
                    Status = a.Status == true ? "Active" : "Pending", // Placeholder logic
                    UpdateDateTime = a.UpdateDateTime
                })
                .Take(50)
                .ToListAsync();

            return Ok(jobs);
        }
    }
}
