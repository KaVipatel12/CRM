using CRM_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LookupsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLookups()
        {
            var contactTypes = await _context.ContactTypes.ToListAsync();
            var relationshipTypes = await _context.RelationShipTypes.ToListAsync();
            var customerTypes = await _context.CustomerTypes.ToListAsync();
            var businessTypes = await _context.BusinessTypes.ToListAsync();
            var taxAgents = await _context.TaxAgents.ToListAsync();
            var tradingStatuses = await _context.TradingStatuses.ToListAsync();
            var staff = await _context.Users.Select(u => new { id = u.Id, u.FirstName, u.LastName }).ToListAsync();
            var jobTypes = await _context.TypeMasters.ToListAsync();
            var jobStatusMasters = await _context.JobStatusMasters.ToListAsync();
            var jobTypeStatusMappings = await _context.JobTypeStatusMappings.ToListAsync();
            var customers = await _context.Customers.Select(c => new { id = c.Id, name = c.Name }).ToListAsync();
            var fsNoteMasters = await _context.FSNoteMasters.Where(m => m.IsActive).OrderBy(m => m.SortOrder).ToListAsync();
            
            return Ok(new
            {
                ContactTypes = contactTypes,
                RelationshipTypes = relationshipTypes,
                CustomerTypes = customerTypes,
                BusinessTypes = businessTypes,
                TaxAgents = taxAgents,
                TradingStatuses = tradingStatuses,
                Staff = staff,
                JobTypes = jobTypes,
                JobStatusMasters = jobStatusMasters,
                JobTypeStatusMappings = jobTypeStatusMappings,
                Customers = customers,
                FSNoteMasters = fsNoteMasters
            });
        }
    }
}
