using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CRM_Api.DTOs;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserTodosController : ControllerBase
    {
        private readonly IUserTodoService _userTodoService;
        private readonly IUserContext _userContext;

        public UserTodosController(IUserTodoService userTodoService, IUserContext userContext)
        {
            _userTodoService = userTodoService;
            _userContext = userContext;
        }

        private int GetCurrentUserId() => _userContext.UserId ?? throw new UnauthorizedAccessException("User not found.");

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = await _userTodoService.GetByUserIdAsync(userId);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserTodoDto dto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = await _userTodoService.AddAsync(userId, dto);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserTodoDto dto)
        {
            try
            {
                var userId = GetCurrentUserId();
                var success = await _userTodoService.UpdateAsync(userId, dto);
                if (!success) return NotFound();
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var success = await _userTodoService.DeleteAsync(userId, id);
                if (!success) return NotFound();
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
