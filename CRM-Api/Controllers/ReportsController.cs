using System.Collections.Generic;
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
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("client-details/fields")]
        public async Task<ActionResult<IEnumerable<ReportFieldDto>>> GetClientDetailsFields([FromQuery] int? clientType)
        {
            var fields = await _reportService.GetAvailableFieldsAsync(clientType);
            return Ok(fields);
        }

        [HttpPost("client-details/export")]
        public async Task<IActionResult> ExportClientDetails([FromBody] ClientDetailsReportFilter filter)
        {
            var data = await _reportService.GenerateClientDetailsReportAsync(filter);
            
            string fileName = $"Client_Details_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";
            string contentType = "text/csv";

            if (filter.ExportFormat == "txt")
            {
                fileName = fileName.Replace(".csv", ".txt");
                contentType = "text/plain";
            }

            return File(data, contentType, fileName);
        }

        [HttpPost("fs-notes/export")]
        public async Task<IActionResult> ExportFSNotes([FromBody] FSNotesReportFilter filter)
        {
            var data = await _reportService.GenerateFSNotesReportAsync(filter);

            string fileName = $"FS_Notes_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";
            string contentType = "text/csv";

            if (filter.ExportFormat == "txt")
            {
                fileName = fileName.Replace(".csv", ".txt");
                contentType = "text/plain";
            }

            return File(data, contentType, fileName);
        }
    }
}
