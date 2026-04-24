using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class CustomerNoteService : ICustomerNoteService
    {
        private readonly AppDbContext _context;

        public CustomerNoteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerNoteDto>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.CustomerNotes
                .Where(n => n.CustomerId == customerId && !n.IsDeleted)
                .OrderByDescending(n => n.IsPinned)
                .ThenByDescending(n => n.CreatedDateTime)
                .Select(n => new CustomerNoteDto
                {
                    Id = n.Id,
                    CustomerId = n.CustomerId,
                    NoteText = n.NoteText,
                    IsPinned = n.IsPinned,
                    CreatedDateTime = n.CreatedDateTime,
                    CreatedUserName = _context.Users
                        .Where(u => u.Id == n.CreatedUserId)
                        .Select(u => u.FirstName + " " + u.LastName)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task<CustomerNoteDto> AddAsync(CreateCustomerNoteDto dto)
        {
            var note = new CustomerNote
            {
                CustomerId = dto.CustomerId,
                NoteText = dto.NoteText,
                IsPinned = dto.IsPinned
            };

            _context.CustomerNotes.Add(note);
            await _context.SaveChangesAsync();

            // Fetch again to get the user name and other generated values
            return await _context.CustomerNotes
                .Where(n => n.Id == note.Id)
                .Select(n => new CustomerNoteDto
                {
                    Id = n.Id,
                    CustomerId = n.CustomerId,
                    NoteText = n.NoteText,
                    IsPinned = n.IsPinned,
                    CreatedDateTime = n.CreatedDateTime,
                    CreatedUserName = _context.Users
                        .Where(u => u.Id == n.CreatedUserId)
                        .Select(u => u.FirstName + " " + u.LastName)
                        .FirstOrDefault()
                })
                .FirstAsync();
        }

        public async Task<bool> UpdateAsync(UpdateCustomerNoteDto dto)
        {
            var note = await _context.CustomerNotes.FindAsync(dto.Id);
            if (note == null) return false;

            note.NoteText = dto.NoteText;
            note.IsPinned = dto.IsPinned;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var note = await _context.CustomerNotes.FindAsync(id);
            if (note == null) return false;

            note.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
