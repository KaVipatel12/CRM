using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Operations;
using CRM_Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }

        private int? GetCurrentUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("id");
            if (int.TryParse(userIdStr, out int userId))
            {
                return userId;
            }
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<JobPagedResponseDto>> GetJobs([FromQuery] JobFilterDto filter)
        {
            var query = _context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                var search = filter.SearchString.ToLower();
                query = query.Where(j => j.Caption.ToLower().Contains(search) || 
                                         (j.Description != null && j.Description.ToLower().Contains(search)) ||
                                         (j.CustomerId.HasValue && j.Customer.Name.ToLower().Contains(search)));
            }

            if (filter.StatusId.HasValue) 
            {
                query = query.Where(j => j.CurrentStage == filter.StatusId);
            }
            else 
            {
                // Default: Hide "Todo Later" (ID 4) and "Completed" (ID 6)
                query = query.Where(j => j.CurrentStage != 4 && j.CurrentStage != 6);
            }
            if (filter.Priority.HasValue) query = query.Where(j => j.Priority == filter.Priority);
            if (filter.JobTypeId.HasValue) query = query.Where(j => j.JobTypeId == filter.JobTypeId);
            if (filter.OwnerId.HasValue) query = query.Where(j => j.OwnerId == filter.OwnerId);
            if (filter.ResponsibleId.HasValue) query = query.Where(j => j.ResponsibleId == filter.ResponsibleId);
            if (filter.CustomerId.HasValue) query = query.Where(j => j.CustomerId == filter.CustomerId);
            
            // Default to only showing Active jobs unless specifically requested
            if (filter.IsActive.HasValue) 
                query = query.Where(j => j.IsActive == filter.IsActive.Value);
            else
                query = query.Where(j => j.IsActive);
                
            if (filter.IsRecurring.HasValue) query = query.Where(j => j.IsRecurring == filter.IsRecurring);
            if (filter.IsInternal.HasValue) query = query.Where(j => j.IsInternal == filter.IsInternal);

            // Total Count before paging
            var totalCount = await query.CountAsync();

            // Paging
            var items = await query
                .OrderByDescending(j => j.UpdateDateTime)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(j => new JobDto
                {
                    Id = j.Id,
                    CustomerId = j.CustomerId,
                    CustomerName = j.CustomerId.HasValue ? j.Customer.Name : "Internal Operation",
                    CustomerCode = j.CustomerId.HasValue ? j.Customer.Code : null,
                    IsInternal = j.IsInternal,
                    JobTypeId = j.JobTypeId,
                    JobTypeName = j.JobType.Type,
                    Caption = j.Caption,
                    Description = j.Description,
                    Priority = j.Priority,
                    CurrentStage = j.CurrentStage,
                    StatusName = j.Status != null ? j.Status.StatusName : "Pending",
                    AssignDate = j.StartDate ?? j.CreatedDate,
                    StartDate = j.StartDate,
                    Deadline = j.Deadline,
                    DaysLeft = j.Deadline.HasValue ? (j.Deadline.Value - DateTime.Now).Days : null,
                    OwnerId = j.OwnerId,
                    ResponsibleId = j.ResponsibleId,
                    OriginalResponsibleId = j.OriginalResponsibleId,
                    TemporaryAssignmentUntil = j.TemporaryAssignmentUntil,
                    Period = j.Period,
                    RecurringMode = j.RecurringMode,
                    TargetEndDate = j.TargetEndDate,
                    DueDateDays = j.DueDateDays,
                    DueDateBasis = j.DueDateBasis,
                    IsActive = j.IsActive,
                    IsRecurring = j.IsRecurring
                })
                .ToListAsync();

            return Ok(new JobPagedResponseDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            });
        }

        [HttpGet("stats")]
        public async Task<ActionResult<JobStatisticsDto>> GetStatistics()
        {
            var now = DateTime.Now;
            // Only count active (non-archived) jobs in the statistics
            var query = _context.Jobs.Where(j => j.IsActive).AsQueryable();

            var stats = new JobStatisticsDto
            {
                TotalActive = await query.CountAsync(j => j.CurrentStage != 4 && j.CurrentStage != 6),
                Active = await query.CountAsync(j => j.CurrentStage == 1 || j.CurrentStage == 2),
                OnHold = await query.CountAsync(j => j.CurrentStage == 3),
                Overdue = await query.CountAsync(j => j.CurrentStage != 6 && j.CurrentStage != 4 && j.Deadline < now),
                TodoLater = await query.CountAsync(j => j.CurrentStage == 4),
                Completed = await query.CountAsync(j => j.CurrentStage == 6)
            };

            return stats;
        }

        [HttpPut("bulk/status")]
        public async Task<IActionResult> BulkUpdateStatus([FromBody] BulkJobStatusUpdateDto request)
        {
            if (request == null || !request.JobIds.Any()) return BadRequest("No job IDs provided.");

            var status = await _context.JobStatusMasters.FindAsync(request.StatusId);
            if (status == null) return BadRequest("Invalid status ID.");

            var jobs = await _context.Jobs
                .Where(j => request.JobIds.Contains(j.Id) && j.CurrentStage != request.StatusId)
                .ToListAsync();

            foreach (var job in jobs)
            {
                job.CurrentStage = request.StatusId;
                job.UpdateDateTime = DateTime.Now;

                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = $"Job status updated to {status.StatusName} via Bulk Action",
                    Timestamp = DateTime.Now,
                    UserId = 0 // Placeholder
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { Count = jobs.Count });
        }

        [HttpPut("bulk/temporary-assign")]
        public async Task<IActionResult> BulkUpdateTemporaryAssignment([FromBody] BulkTemporaryAssignmentDto request)
        {
            if (request == null || !request.JobIds.Any()) return BadRequest("No job IDs provided.");

            var jobs = await _context.Jobs
                .Where(j => request.JobIds.Contains(j.Id))
                .ToListAsync();

            foreach (var job in jobs)
            {
                if (job.OriginalResponsibleId == null)
                {
                    job.OriginalResponsibleId = job.ResponsibleId;
                }
                job.ResponsibleId = request.StaffId;
                job.TemporaryAssignmentUntil = request.UntilDate.Date.AddDays(1).AddSeconds(-1); // End of the day
                job.TemporaryAssignmentNote = request.Note;
                job.UpdateDateTime = DateTime.Now;

                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = $"Temporarily assigned to Staff ID {request.StaffId} until {request.UntilDate:yyyy-MM-dd}. Reason: {request.Note}",
                    Timestamp = DateTime.Now,
                    UserId = 0 // Placeholder
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { Count = jobs.Count });
        }


        [HttpGet("export")]
        public async Task<IActionResult> Export([FromQuery] JobFilterDto filter)
        {
            var query = _context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .AsQueryable();

            // Apply same filters as GetJobs but NO Paging
            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                var search = filter.SearchString.ToLower();
                query = query.Where(j => j.Caption.ToLower().Contains(search) || 
                                         (j.Description != null && j.Description.ToLower().Contains(search)) ||
                                         (j.CustomerId.HasValue && j.Customer.Name.ToLower().Contains(search)));
            }

            if (filter.StatusId.HasValue) query = query.Where(j => j.CurrentStage == filter.StatusId);
            if (filter.Priority.HasValue) query = query.Where(j => j.Priority == filter.Priority);
            if (filter.JobTypeId.HasValue) query = query.Where(j => j.JobTypeId == filter.JobTypeId);
            if (filter.OwnerId.HasValue) query = query.Where(j => j.OwnerId == filter.OwnerId);
            if (filter.ResponsibleId.HasValue) query = query.Where(j => j.ResponsibleId == filter.ResponsibleId);
            if (filter.CustomerId.HasValue) query = query.Where(j => j.CustomerId == filter.CustomerId);
            if (filter.IsActive.HasValue) query = query.Where(j => j.IsActive == filter.IsActive);
            if (filter.IsRecurring.HasValue) query = query.Where(j => j.IsRecurring == filter.IsRecurring);
            if (filter.IsInternal.HasValue) query = query.Where(j => j.IsInternal == filter.IsInternal);

            var jobs = await query
                .OrderByDescending(j => j.UpdateDateTime)
                .Select(j => new
                {
                    j.Id,
                    Customer = j.CustomerId.HasValue ? j.Customer.Name : "Internal",
                    Type = j.JobType.Type,
                    j.Caption,
                    Priority = j.Priority == 1 ? "Low" : (j.Priority == 2 ? "Medium" : (j.Priority == 3 ? "High" : "Urgent")),
                    Status = j.Status != null ? j.Status.StatusName : "Pending",
                    Deadline = j.Deadline,
                    CreatedDate = j.CreatedDate
                })
                .ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Jobs");

                // Headers
                var headers = new[] { "ID", "Customer", "Job Type", "Caption", "Priority", "Status", "Deadline", "Created Date" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Data
                for (int i = 0; i < jobs.Count; i++)
                {
                    var job = jobs[i];
                    worksheet.Cells[i + 2, 1].Value = job.Id;
                    worksheet.Cells[i + 2, 2].Value = job.Customer;
                    worksheet.Cells[i + 2, 3].Value = job.Type;
                    worksheet.Cells[i + 2, 4].Value = job.Caption;
                    worksheet.Cells[i + 2, 5].Value = job.Priority;
                    worksheet.Cells[i + 2, 6].Value = job.Status;
                    worksheet.Cells[i + 2, 7].Value = job.Deadline?.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 8].Value = job.CreatedDate.ToString("yyyy-MM-dd");
                }

                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"JobsList-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobsByCustomer(int customerId)
        {
            var jobs = await _context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .Where(j => j.CustomerId == customerId)
                .OrderByDescending(j => j.UpdateDateTime)
                .Select(j => new JobDto
                {
                    Id = j.Id,
                    CustomerId = j.CustomerId,
                    CustomerName = j.CustomerId.HasValue ? j.Customer.Name : "Internal Operation",
                    CustomerCode = j.CustomerId.HasValue ? j.Customer.Code : null,
                    IsInternal = j.IsInternal,
                    JobTypeId = j.JobTypeId,
                    JobTypeName = j.JobType.Type,
                    Caption = j.Caption,
                    Description = j.Description,
                    Priority = j.Priority,
                    CurrentStage = j.CurrentStage,
                    StatusName = j.Status != null ? j.Status.StatusName : "Pending",
                    AssignDate = j.StartDate ?? j.CreatedDate,
                    StartDate = j.StartDate,
                    Deadline = j.Deadline,
                    DaysLeft = j.Deadline.HasValue ? (j.Deadline.Value - DateTime.Now).Days : null,
                    OwnerId = j.OwnerId,
                    ResponsibleId = j.ResponsibleId,
                    OriginalResponsibleId = j.OriginalResponsibleId,
                    TemporaryAssignmentUntil = j.TemporaryAssignmentUntil,
                    Period = j.Period,
                    TargetEndDate = j.TargetEndDate,
                    DueDateDays = j.DueDateDays,
                    DueDateBasis = j.DueDateBasis,
                    IsActive = j.IsActive,
                    IsRecurring = j.IsRecurring
                })
                .ToListAsync();

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .Include(j => j.Tasks.OrderBy(t => t.Sequence))
                .Include(j => j.Comments.OrderByDescending(c => c.CreatedAt))
                .Include(j => j.History.OrderByDescending(h => h.Timestamp))
                .FirstOrDefaultAsync(j => j.Id == id);

            if (job == null) return NotFound();

            var dto = new JobDto
            {
                Id = job.Id,
                CustomerId = job.CustomerId,
                CustomerName = job.CustomerId.HasValue ? job.Customer.Name : "Office Schedule",
                CustomerCode = job.CustomerId.HasValue ? job.Customer.Code : null,
                IsInternal = job.IsInternal,
                JobTypeId = job.JobTypeId,
                JobTypeName = job.JobType.Type,
                Caption = job.Caption,
                Description = job.Description,
                Priority = job.Priority,
                CurrentStage = job.CurrentStage,
                StatusName = job.Status != null ? job.Status.StatusName : "Pending",
                AssignDate = job.StartDate ?? job.CreatedDate,
                StartDate = job.StartDate,
                Deadline = job.Deadline,
                DaysLeft = job.Deadline.HasValue ? (job.Deadline.Value - DateTime.Now).Days : null,
                OwnerId = job.OwnerId,
                ResponsibleId = job.ResponsibleId,
                OriginalResponsibleId = job.OriginalResponsibleId,
                TemporaryAssignmentUntil = job.TemporaryAssignmentUntil,
                Period = job.Period,
                RecurringMode = job.RecurringMode,
                TargetEndDate = job.TargetEndDate,
                DueDateDays = job.DueDateDays,
                DueDateBasis = job.DueDateBasis,
                IsActive = job.IsActive,
                IsRecurring = job.IsRecurring,
                Tasks = job.Tasks.Select(t => new JobTaskDto
                {
                    Id = t.Id,
                    JobId = t.JobId,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    CompletedDate = t.CompletedDate,
                    Sequence = t.Sequence
                }).ToList(),
                Comments = job.Comments.Select(c => new JobCommentDto
                {
                    Id = c.Id,
                    JobId = c.JobId,
                    UserId = c.UserId,
                    UserName = _context.Users.Where(u => u.Id == c.UserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault() ?? "Unknown",
                    Text = c.Text,
                    CreatedAt = c.CreatedAt
                }).ToList(),
                History = job.History.Select(h => new JobHistoryDto
                {
                    Id = h.Id,
                    JobId = h.JobId,
                    Event = h.Event,
                    UserId = h.UserId,
                    UserName = _context.Users.Where(u => u.Id == h.UserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault() ?? "System",
                    Timestamp = h.Timestamp
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<JobDto>> CreateJob(JobCreateUpdateDto dto)
        {
            var job = new Job
            {
                CustomerId = dto.CustomerId,
                JobTypeId = dto.JobTypeId,
                Caption = dto.Caption!,
                Description = dto.Description,
                Priority = dto.Priority,
                CurrentStage = dto.CurrentStage ?? 1, 
                StartDate = dto.StartDate,
                Deadline = dto.Deadline,
                OwnerId = dto.OwnerId,
                ResponsibleId = dto.ResponsibleId,
                Period = dto.Period,
                RecurringMode = dto.RecurringMode,
                TargetEndDate = dto.TargetEndDate,
                DueDateDays = dto.DueDateDays,
                DueDateBasis = dto.DueDateBasis,
                IsActive = true,
                IsRecurring = dto.IsRecurring,
                IsInternal = dto.IsInternal,
                CreatedDate = DateTime.Now
            };

            // Calculate initial deadline for recurring jobs if not provided
            if (job.IsRecurring && !job.Deadline.HasValue && job.StartDate.HasValue)
            {
                job.Deadline = JobScheduleHelper.CalculateDeadline(job.StartDate.Value, job.DueDateDays, job.DueDateBasis);
            }

            // Calculate initial NextAutoCreateDate for recurring jobs
            if (job.IsRecurring && job.StartDate.HasValue && !string.IsNullOrEmpty(job.RecurringMode))
            {
                job.NextAutoCreateDate = JobScheduleHelper.CalculateNextCreationDate(job.StartDate.Value, job.RecurringMode);
            }

            var currentUserId = GetCurrentUserId();
            job.UpdateUserId = currentUserId;

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            // Save Tasks if any are provided inline
            if (dto.Tasks != null && dto.Tasks.Any())
            {
                var tasks = dto.Tasks.Select(t => new JobTask
                {
                    JobId = job.Id,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Sequence = t.Sequence,
                    CreatedDate = DateTime.Now
                }).ToList();
                
                _context.JobTasks.AddRange(tasks);
                await _context.SaveChangesAsync();
            }

            // Log Initial History
            _context.JobHistories.Add(new JobHistory
            {
                JobId = job.Id,
                Event = "Job Created",
                Timestamp = DateTime.Now,
                UserId = currentUserId ?? 0
            });
            await _context.SaveChangesAsync();

            return await GetJob(job.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobCreateUpdateDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            bool stageChanged = job.CurrentStage != dto.CurrentStage;
            int? oldStage = job.CurrentStage;

            job.JobTypeId = dto.JobTypeId;
            job.Caption = dto.Caption!;
            job.Description = dto.Description;
            job.Priority = dto.Priority;
            job.CurrentStage = dto.CurrentStage;
            job.StartDate = dto.StartDate;
            job.Deadline = dto.Deadline;
            job.OwnerId = dto.OwnerId;
            job.UpdateUserId = GetCurrentUserId();
            job.IsRecurring = dto.IsRecurring;
            job.IsInternal = dto.IsInternal;
            job.Period = dto.Period;
            job.RecurringMode = dto.RecurringMode;
            job.TargetEndDate = dto.TargetEndDate;
            job.DueDateDays = dto.DueDateDays;
            job.DueDateBasis = dto.DueDateBasis;

            // Recalculate NextAutoCreateDate if recurring settings changed
            // Only set if this job doesn't already have children (is the latest in chain)
            if (job.IsRecurring && job.StartDate.HasValue && !string.IsNullOrEmpty(job.RecurringMode))
            {
                bool hasChild = await _context.Jobs.AnyAsync(child => child.ParentJobId == job.Id);
                if (!hasChild)
                {
                    job.NextAutoCreateDate = JobScheduleHelper.CalculateNextCreationDate(job.StartDate.Value, job.RecurringMode);
                }
            }
            else
            {
                job.NextAutoCreateDate = null;
            }
            
            // If the assignee is manually changed from the Edit form, abort any active temporary assignment
            if (job.ResponsibleId != dto.ResponsibleId)
            {
                job.ResponsibleId = dto.ResponsibleId;
                job.OriginalResponsibleId = null;
                job.TemporaryAssignmentUntil = null;
                job.TemporaryAssignmentNote = null;
            }
            job.UpdateDateTime = DateTime.Now;

            if (stageChanged)
            {
                var newStatus = await _context.JobStatusMasters.FindAsync(dto.CurrentStage);
                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = $"Status changed to {newStatus?.StatusName ?? "Unknown"}",
                    Timestamp = DateTime.Now
                });
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/tasks")]
        public async Task<ActionResult<JobTaskDto>> AddTask(int id, [FromBody] string description)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            var taskCount = await _context.JobTasks.CountAsync(t => t.JobId == id);
            var task = new JobTask
            {
                JobId = id,
                Description = description,
                IsCompleted = false,
                Sequence = taskCount + 1,
                CreatedDate = DateTime.Now
            };

            _context.JobTasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(new JobTaskDto 
            { 
                Id = task.Id, 
                JobId = task.JobId, 
                Description = task.Description, 
                IsCompleted = task.IsCompleted, 
                Sequence = task.Sequence 
            });
        }

        [HttpPut("tasks/{taskId}/toggle")]
        public async Task<IActionResult> ToggleTask(int taskId)
        {
            var task = await _context.JobTasks.FindAsync(taskId);
            if (task == null) return NotFound();

            task.IsCompleted = !task.IsCompleted;
            task.CompletedDate = task.IsCompleted ? DateTime.Now : null;
            task.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<JobCommentDto>> AddComment(int id, [FromBody] string text)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            // Get the logged-in user's ID from JWT
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                               ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            int userId = 0;
            if (!string.IsNullOrEmpty(userIdString)) int.TryParse(userIdString, out userId);

            var comment = new JobComment
            {
                JobId = id,
                UserId = userId,
                Text = text,
                CreatedAt = DateTime.Now
            };

            _context.JobComments.Add(comment);
            await _context.SaveChangesAsync();

            // Look up user name
            var userName = await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.FirstName + " " + u.LastName)
                .FirstOrDefaultAsync() ?? "System";

            return Ok(new JobCommentDto
            {
                Id = comment.Id,
                JobId = comment.JobId,
                UserId = comment.UserId,
                UserName = userName,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt
            });
        }

        [HttpDelete("comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _context.JobComments.FindAsync(commentId);
            if (comment == null) return NotFound();

            // Get logged-in user
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                               ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            int userId = 0;
            if (!string.IsNullOrEmpty(userIdString)) int.TryParse(userIdString, out userId);

            // Check: only comment owner or admin can delete
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            bool isAdmin = roles.Contains("SuperAdmin") || roles.Contains("Admin");

            if (comment.UserId != userId && !isAdmin)
                return Forbid("You can only delete your own comments.");

            _context.JobComments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("tasks/{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var task = await _context.JobTasks.FindAsync(taskId);
            if (task == null) return NotFound();

            _context.JobTasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}/close")]
        public async Task<IActionResult> CloseJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            job.CurrentStage = 6; // Completed
            job.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ArchiveJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            job.IsActive = false;
            job.UpdateUserId = GetCurrentUserId();
            job.UpdateDateTime = DateTime.Now;

            _context.JobHistories.Add(new JobHistory
            {
                JobId = job.Id,
                Event = "Job Archived (Soft Delete)",
                Timestamp = DateTime.Now,
                UserId = job.UpdateUserId ?? 0
            });

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("bulk/archive")]
        public async Task<IActionResult> BulkArchive([FromBody] List<int> jobIds)
        {
            if (jobIds == null || !jobIds.Any()) return BadRequest("No job IDs provided.");

            var jobs = await _context.Jobs.Where(j => jobIds.Contains(j.Id)).ToListAsync();
            var currentUserId = GetCurrentUserId();

            foreach (var job in jobs)
            {
                job.IsActive = false;
                job.UpdateUserId = currentUserId;
                job.UpdateDateTime = DateTime.Now;

                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = "Job Archived (Bulk Action)",
                    Timestamp = DateTime.Now,
                    UserId = currentUserId ?? 0
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { success = true, count = jobs.Count });
        }
    }
}
