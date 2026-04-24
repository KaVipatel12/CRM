using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class UserNoteService : IUserNoteService
    {
        private readonly AppDbContext _context;

        public UserNoteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserNoteDto>> GetByUserIdAsync(int userId)
        {
            return await _context.UserNotes
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.IsPinned)
                .ThenBy(n => n.DisplayOrder)
                .ThenByDescending(n => n.CreatedDateTime)
                .Select(n => new UserNoteDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    IsPinned = n.IsPinned,
                    DisplayOrder = n.DisplayOrder,
                    CreatedDateTime = n.CreatedDateTime,
                    UpdateDateTime = n.UpdateDateTime
                })
                .ToListAsync();
        }

        public async Task<UserNoteDto> AddAsync(int userId, CreateUserNoteDto dto)
        {
            var note = new UserNote
            {
                Title = dto.Title,
                Content = dto.Content,
                IsPinned = dto.IsPinned,
                DisplayOrder = dto.DisplayOrder,
                UserId = userId
            };

            _context.UserNotes.Add(note);
            await _context.SaveChangesAsync();

            return new UserNoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                IsPinned = note.IsPinned,
                DisplayOrder = note.DisplayOrder,
                CreatedDateTime = note.CreatedDateTime,
                UpdateDateTime = note.UpdateDateTime
            };
        }

        public async Task<bool> UpdateAsync(int userId, UpdateUserNoteDto dto)
        {
            var note = await _context.UserNotes.FirstOrDefaultAsync(n => n.Id == dto.Id && n.UserId == userId);

            if (note == null)
            {
                return false;
            }

            note.Title = dto.Title;
            note.Content = dto.Content;
            note.IsPinned = dto.IsPinned;
            note.DisplayOrder = dto.DisplayOrder;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int userId, int id)
        {
            var note = await _context.UserNotes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null)
            {
                return false;
            }

            _context.UserNotes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int?> ConvertToTodoAsync(int userId, int id)
        {
            var note = await _context.UserNotes
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null)
                return null;

            // Strip HTML tags and decode entities (like &nbsp;) from content
            var plainTextContent = System.Text.RegularExpressions.Regex.Replace(note.Content, "<.*?>", string.Empty);
            plainTextContent = System.Net.WebUtility.HtmlDecode(plainTextContent).Trim();
            
            // Only use Title if it exists, otherwise use the cleaned plain text content
            var finalNoteStr = string.IsNullOrWhiteSpace(note.Title) ? plainTextContent : note.Title;

            // Create new Todo based on the note
            var todo = new UserTodo
            {
                UserId = userId,
                Note = finalNoteStr,
                IsCompleted = false
            };

            _context.UserTodos.Add(todo);

            // Remove the note as it is converted
            _context.UserNotes.Remove(note);

            await _context.SaveChangesAsync();

            return todo.Id;
        }

        public async Task<bool> UpdateOrderAsync(int userId, IEnumerable<UpdateNoteOrderDto> updates)
        {
            var noteIds = updates.Select(u => u.Id).ToList();
            
            var notes = await _context.UserNotes
                .Where(n => n.UserId == userId && noteIds.Contains(n.Id))
                .ToListAsync();

            if (!notes.Any())
                return false;

            foreach (var note in notes)
            {
                var update = updates.FirstOrDefault(u => u.Id == note.Id);
                if (update != null)
                {
                    note.DisplayOrder = update.DisplayOrder;
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
