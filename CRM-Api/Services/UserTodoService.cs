using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Services
{
    public class UserTodoService : IUserTodoService
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;

        public UserTodoService(AppDbContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        private int GetCurrentUserId()
        {
            return _userContext.UserId ?? throw new UnauthorizedAccessException("User context is missing.");
        }

        public async Task<IEnumerable<UserTodoDto>> GetByUserIdAsync(int userId)
        {
            return await _context.UserTodos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedDateTime)
                .Select(t => new UserTodoDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Note = t.Note,
                    IsCompleted = t.IsCompleted,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    CreatedDateTime = t.CreatedDateTime
                })
                .ToListAsync();
        }

        public async Task<UserTodoDto> AddAsync(int userId, CreateUserTodoDto dto)
        {
            var todo = new UserTodo
            {
                UserId = userId,
                Note = dto.Note,
                DueDate = dto.DueDate,
                Priority = dto.Priority,
                IsCompleted = false
            };

            _context.UserTodos.Add(todo);
            await _context.SaveChangesAsync();

            return new UserTodoDto
            {
                Id = todo.Id,
                UserId = todo.UserId,
                Note = todo.Note,
                IsCompleted = todo.IsCompleted,
                DueDate = todo.DueDate,
                Priority = todo.Priority,
                CreatedDateTime = todo.CreatedDateTime
            };
        }

        public async Task<bool> UpdateAsync(int userId, UpdateUserTodoDto dto)
        {
            var todo = await _context.UserTodos
                .FirstOrDefaultAsync(t => t.Id == dto.Id && t.UserId == userId);

            if (todo == null) return false;

            todo.Note = dto.Note;
            todo.IsCompleted = dto.IsCompleted;
            todo.DueDate = dto.DueDate;
            todo.Priority = dto.Priority;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int userId, int id)
        {
            var todo = await _context.UserTodos
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (todo == null) return false;

            _context.UserTodos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
