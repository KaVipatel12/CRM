using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BranchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Branch/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranchesByCustomer(int customerId)
        {
            return await _context.Branches
                .Where(b => b.CustomerID == customerId)
                .Select(b => new BranchDto
                {
                    Id = b.Id,
                    CustomerId = b.CustomerID,
                    BranchName = b.BranchName
                })
                .ToListAsync();
        }

        // POST: api/Branch
        [HttpPost]
        public async Task<ActionResult<BranchDto>> CreateBranch(BranchDto branchDto)
        {
            var branch = new Branch
            {
                CustomerID = branchDto.CustomerId,
                BranchName = branchDto.BranchName
            };

            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            branchDto.Id = branch.Id;
            return CreatedAtAction(nameof(GetBranchesByCustomer), new { customerId = branch.CustomerID }, branchDto);
        }

        // PUT: api/Branch/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchDto branchDto)
        {
            if (id != branchDto.Id) return BadRequest();

            var branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();

            branch.BranchName = branchDto.BranchName;
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Branch/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();

            // Note: If addresses are linked to this branch, you might want to handle that.
            // For now, we'll just set BranchID to null for those addresses.
            var linkedAddresses = await _context.Addresses.Where(a => a.BranchID == id).ToListAsync();
            foreach (var addr in linkedAddresses)
            {
                addr.BranchID = null;
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
