using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Utilities;
using CRM_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CRM_Api.Services.Interfaces;

namespace CRM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileUploadController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;
        private readonly string _uploadPath;

        public FileUploadController(ICustomerService customerService, AppDbContext context, IUserContext userContext)
        {
            _customerService = customerService;
            _context = context;
            _userContext = userContext;
            _uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Uploads");

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<FileUploadInfoDto>>> GetHistory()
        {
            var history = await _customerService.GetUploadHistoryAsync();
            return Ok(history);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<FileUploadInfoDto>> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var userId = _userContext.UserId;
            if (userId == null) return Unauthorized();

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileInfo = new FileUploadInfo
            {
                FileType = 1, // Customer
                FileOriginalName = file.FileName,
                FileServerPath = Path.Combine("Resources", "Uploads", fileName),
                FileSize = file.Length,
                UploadedBy = userId.Value,
                UploadDate = DateTime.Now,
                ProcessResult = 0, // Pending
                ProcessResultLogFile = ""
            };

            _context.FileUploadInfos.Add(fileInfo);
            await _context.SaveChangesAsync();

            return Ok(new FileUploadInfoDto
            {
                Id = fileInfo.Id,
                FileOriginalName = fileInfo.FileOriginalName,
                UploadDate = fileInfo.UploadDate,
                ProcessResult = fileInfo.ProcessResult
            });
        }

        [HttpPost("process/{id}")]
        public async Task<ActionResult<FileUploadInfoDto>> Process(int id)
        {
            try
            {
                var result = await _customerService.ProcessFileAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
