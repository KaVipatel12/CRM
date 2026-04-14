using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserNotesController : ControllerBase
    {
        private readonly IUserNoteService _userNoteService;
        private readonly IUserContext _userContext;

        public UserNotesController(IUserNoteService userNoteService, IUserContext userContext)
        {
            _userNoteService = userNoteService;
            _userContext = userContext;
        }

        private int GetCurrentUserId() => _userContext.UserId ?? throw new UnauthorizedAccessException("User not found.");

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNoteDto>>> GetNotes()
        {
            try
            {
                var userId = GetCurrentUserId();
                var notes = await _userNoteService.GetByUserIdAsync(userId);
                return Ok(notes);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserNoteDto>> CreateNote(CreateUserNoteDto createDto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var note = await _userNoteService.AddAsync(userId, createDto);
                return CreatedAtAction(nameof(GetNotes), new { id = note.Id }, note);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNote(int id, UpdateUserNoteDto updateDto)
        {
            if (id != updateDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var userId = GetCurrentUserId();
                var success = await _userNoteService.UpdateAsync(userId, updateDto);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var success = await _userNoteService.DeleteAsync(userId, id);

                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("{id:int}/convert-to-todo")]
        public async Task<IActionResult> ConvertToTodo(int id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var todoId = await _userNoteService.ConvertToTodoAsync(userId, id);

                if (todoId == null)
                {
                    return NotFound();
                }

                return Ok(new { todoId });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPut("reorder")]
        public async Task<IActionResult> ReorderNotes(IEnumerable<UpdateNoteOrderDto> updates)
        {
            try
            {
                var userId = GetCurrentUserId();
                var success = await _userNoteService.UpdateOrderAsync(userId, updates);

                if (!success)
                {
                    return BadRequest("Failed to update note order.");
                }

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
