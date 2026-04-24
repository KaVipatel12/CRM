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
    public class FSNoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FSNoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/fsnote/{customerId}
        [HttpGet("{customerId}")]
        public async Task<ActionResult<object>> GetFSNotesForCustomer(int customerId)
        {
            // Fetch Master Types (e.g., Retained Earnings, Common Note)
            var masterTypes = await _context.FSNoteMasters
                .Where(m => m.IsActive)
                .OrderBy(m => m.SortOrder)
                .Select(m => new { m.Id, m.NoteType })
                .ToListAsync();

            // Fetch actual notes for this customer
            var notes = await _context.CustomerFSNotes
                .Include(n => n.FSNoteMaster)
                .Include(n => n.UpdatedByUser)
                .Include(n => n.CreatedByUser)
                .Where(n => n.CustomerID == customerId)
                .OrderByDescending(n => n.UpdateDateTime)
                .Select(n => new FSNoteDto
                {
                    Id = n.Id,
                    CustomerId = n.CustomerID,
                    FSNoteMasterId = n.FSNoteMasterID,
                    NoteType = n.FSNoteMaster != null ? n.FSNoteMaster.NoteType : "Unknown",
                    NoteContent = n.NoteContent,
                    CreatedDateTime = n.CreatedDateTime,
                    CreatedByUserName = n.CreatedByUser != null 
                        ? (string.IsNullOrEmpty(n.CreatedByUser.FirstName + n.CreatedByUser.LastName) 
                            ? n.CreatedByUser.UserName 
                            : (n.CreatedByUser.FirstName + " " + n.CreatedByUser.LastName).Trim())
                        : "System",
                    UpdateDateTime = n.UpdateDateTime,
                    UpdatedByUserName = n.UpdatedByUser != null 
                        ? (string.IsNullOrEmpty(n.UpdatedByUser.FirstName + n.UpdatedByUser.LastName) 
                            ? n.UpdatedByUser.UserName 
                            : (n.UpdatedByUser.FirstName + " " + n.UpdatedByUser.LastName).Trim())
                        : "System"
                })
                .ToListAsync();

            return Ok(new { masterTypes, notes });
        }

        // POST: api/fsnote
        [Authorize(Roles = "Admin,Checker,SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateFSNote([FromBody] CreateFSNoteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NoteContent))
                return BadRequest("Note content cannot be empty.");

            var note = new CustomerFSNote
            {
                CustomerID = dto.CustomerId,
                FSNoteMasterID = dto.FSNoteMasterId,
                NoteContent = dto.NoteContent
            };

            _context.CustomerFSNotes.Add(note);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        // PUT: api/fsnote/{id}
        [Authorize(Roles = "Admin,Checker,SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFSNote(int id, [FromBody] CreateFSNoteDto dto)
        {
            var note = await _context.CustomerFSNotes.FindAsync(id);
            if (note == null) return NotFound();

            if (string.IsNullOrWhiteSpace(dto.NoteContent))
                return BadRequest("Note content cannot be empty.");

            note.NoteContent = dto.NoteContent;
            note.FSNoteMasterID = dto.FSNoteMasterId; // Allow changing type if needed
            
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        // DELETE: api/fsnote/{id}
        [Authorize(Roles = "Admin,Checker,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFSNote(int id)
        {
            var note = await _context.CustomerFSNotes.FindAsync(id);
            if (note == null) return NotFound();

            _context.CustomerFSNotes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
    }
}
