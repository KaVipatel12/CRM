using CRM_Api.DTOs;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallsController : ControllerBase
    {
        private readonly ICallService _callService;

        public CallsController(ICallService callService)
        {
            _callService = callService;
        }

        [HttpGet]
        public async Task<ActionResult<CallLogPagedResponseDto>> GetCalls([FromQuery] CallLogFilterDto filter)
        {
            var result = await _callService.GetCallsAsync(filter);
            return Ok(result);
        }

        [HttpGet("purposes")]
        public async Task<ActionResult<IEnumerable<PurposeDto>>> GetPurposes()
        {
            var result = await _callService.GetPurposesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CallLogDto>> CreateCall(CallLogCreateDto createDto)
        {
            var result = await _callService.CreateCallAsync(createDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CallLogDto>> UpdateCall(int id, CallLogCreateDto updateDto)
        {
            var result = await _callService.UpdateCallAsync(id, updateDto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CallLogDto>> GetCallById(int id)
        {
            var result = await _callService.GetCallByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int statusId)
        {
            var success = await _callService.UpdateStatusAsync(id, statusId);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/close")]
        public async Task<IActionResult> CloseCall(int id)
        {
            var success = await _callService.CloseCallAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<CallLogCommentDto>>> GetComments(int id)
        {
            var result = await _callService.GetCommentsAsync(id);
            return Ok(result);
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<CallLogCommentDto>> AddComment(int id, [FromBody] string comment)
        {
            return Ok(await _callService.AddCommentAsync(id, comment));
        }

        [HttpPut("comments/{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId, [FromBody] string comment)
        {
            var result = await _callService.UpdateCommentAsync(commentId, comment);
            if (!result) return BadRequest("Could not update comment. It might not exist or you don't have permission.");
            return Ok();
        }

        [HttpDelete("comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var result = await _callService.DeleteCommentAsync(commentId);
            if (!result) return BadRequest("Could not delete comment. It might not exist or you don't have permission.");
            return Ok();
        }
    }
}
