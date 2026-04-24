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
using CRM_Api.Services.Interfaces;

namespace CRM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;
        private readonly IJobNotificationService _notificationService;

        public JobsController(AppDbContext context, IUserContext userContext, IJobNotificationService notificationService)
        {
            _context = context;
            _userContext = userContext;
            _notificationService = notificationService;
        }

        private int? GetCurrentUserId()
        {
            return _userContext.UserId;
        }

        [HttpGet]
        public async Task<ActionResult<JobPagedResponseDto>> GetJobs([FromQuery] JobFilterDto filter)
        {
            var query = _context.Jobs
                .Include(j => j.Customer)
                    .ThenInclude(c => c.ContactInfo)
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
                // Default: Hide "Todo Later" (ID 10) and "Completed" (ID 12)
                query = query.Where(j => j.CurrentStage != 10 && j.CurrentStage != 12);
            }
            if (filter.Priority.HasValue) 
            {
                if (filter.Priority == 3) // Overdue
                {
                    query = query.Where(j => j.Deadline.HasValue && j.Deadline.Value < DateTime.Now);
                }
                else
                {
                    query = query.Where(j => j.Priority == filter.Priority);
                }
            }

            if (filter.JobTypeId.HasValue) query = query.Where(j => j.JobTypeId == filter.JobTypeId);
            if (filter.OwnerId.HasValue) query = query.Where(j => j.OwnerId == filter.OwnerId);
            if (filter.ResponsibleId.HasValue) query = query.Where(j => j.ResponsibleId == filter.ResponsibleId);
            if (filter.CreatedUserId.HasValue) query = query.Where(j => j.CreatedUserId == filter.CreatedUserId);
            if (filter.CustomerId.HasValue) query = query.Where(j => j.CustomerId == filter.CustomerId);
            
            // Default to only showing Active jobs unless specifically requested or filtering by a final status
            if (filter.IsActive.HasValue) 
            {
                query = query.Where(j => j.IsActive == filter.IsActive.Value);
            }
            else if (filter.StatusId == 12 || filter.StatusId == 10)
            {
                // If explicitly looking for Completed or Todo Later, include them regardless of default active filter
                query = query.Where(j => j.IsActive || !j.IsActive); 
            }
            else
            {
                query = query.Where(j => j.IsActive);
            }
                
            if (filter.IsRecurring.HasValue) query = query.Where(j => j.IsRecurring == filter.IsRecurring);
            if (filter.IsInternal.HasValue) query = query.Where(j => j.IsInternal == filter.IsInternal);
            
            if (filter.DeadlineFrom.HasValue) 
                query = query.Where(j => j.Deadline >= filter.DeadlineFrom.Value.Date);
            if (filter.DeadlineTo.HasValue) 
                query = query.Where(j => j.Deadline <= filter.DeadlineTo.Value.Date.AddDays(1).AddTicks(-1));

            // Total Count before paging
            var totalCount = await query.CountAsync();

            // Paging and Sorting
            bool isAsc = filter.OrderDirection?.ToLower() == "asc";
            string orderBy = filter.OrderBy?.ToLower() ?? "deadline";

            switch (orderBy)
            {
                case "deadline":
                case "daysleft":
                    query = isAsc ? query.OrderBy(j => j.Deadline) : query.OrderByDescending(j => j.Deadline);
                    break;
                case "assigndate":
                    query = isAsc ? query.OrderBy(j => j.StartDate ?? j.CreatedDateTime) : query.OrderByDescending(j => j.StartDate ?? j.CreatedDateTime);
                    break;
                case "caption":
                    query = isAsc ? query.OrderBy(j => j.Caption) : query.OrderByDescending(j => j.Caption);
                    break;
                case "priority":
                    query = isAsc ? query.OrderBy(j => j.Priority) : query.OrderByDescending(j => j.Priority);
                    break;
                default:
                    query = query.OrderByDescending(j => j.Deadline);
                    break;
            }

            // Secondary sort for stability
            query = ((IOrderedQueryable<Job>)query).ThenByDescending(j => j.UpdateDateTime);

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(j => new JobDto
                {           
                    Id = j.Id,
                    CustomerId = j.CustomerId,
                    CustomerName = j.CustomerId.HasValue ? j.Customer.Name : "Internal Operation",
                    CustomerCode = j.CustomerId.HasValue ? j.Customer.Code : null,
                    CustomerEmail = j.CustomerId.HasValue && j.Customer.ContactInfo != null ? j.Customer.ContactInfo.Email : null,
                    CustomerPhone = j.CustomerId.HasValue && j.Customer.ContactInfo != null ? (j.Customer.ContactInfo.CellPhone ?? j.Customer.ContactInfo.WorkPhone) : null,
                    IsInternal = j.IsInternal,
                    JobTypeId = j.JobTypeId,
                    JobTypeName = j.JobType.Type,
                    Caption = j.Caption,
                    Description = j.Description,
                    Priority = j.Priority,
                    CurrentStage = j.CurrentStage,
                    StatusName = j.Status != null ? j.Status.StatusName : "Pending",
                    StatusColor = j.Status != null ? j.Status.Color : "gray",
                    StatusIcon = j.Status != null ? j.Status.Icon : null,
                    AssignDate = j.StartDate ?? j.CreatedDateTime,
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
                    IsRecurring = j.IsRecurring,
                    CreatedUserId = j.CreatedUserId,
                    CreatedUserName = _context.Users.Where(u => u.Id == j.CreatedUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    CreatedDateTime = j.CreatedDateTime
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
        public async Task<ActionResult<JobStatisticsDto>> GetStatistics([FromQuery] bool global = false)
        {
            var now = DateTime.Now;
            var currentUserId = GetCurrentUserId();
            
            // Base query: Only active (non-archived) jobs
            var query = _context.Jobs.Where(j => j.IsActive).AsQueryable();

            // Filter by user unless 'global' view is requested (Admin only)
            if (!global && currentUserId.HasValue)
            {
                query = query.Where(j => j.OwnerId == currentUserId || j.ResponsibleId == currentUserId);
            }

            var stats = new JobStatisticsDto
            {
                TotalActive = await query.CountAsync(j => j.CurrentStage != 10 && j.CurrentStage != 12),
                Active = await query.CountAsync(j => j.CurrentStage == 2 || j.CurrentStage == 5),
                OnHold = await query.CountAsync(j => j.CurrentStage == 9),
                Overdue = await query.CountAsync(j => j.Deadline != null && j.Deadline < now && j.CurrentStage != 12),
                CreatedByMe = await _context.Jobs.CountAsync(j => j.IsActive && j.CreatedUserId == currentUserId && j.CurrentStage != 12),
                OwnedByMe = await _context.Jobs.CountAsync(j => j.IsActive && j.OwnerId == currentUserId && j.CurrentStage != 12),
                HighPriority = await query.CountAsync(j => j.Priority >= 2 && j.CurrentStage != 12),
                TemporaryTasks = await query.CountAsync(j => j.TemporaryAssignmentUntil != null && j.TemporaryAssignmentUntil > now),
                TodoLater = await query.CountAsync(j => j.CurrentStage == 10),
                Completed = await query.CountAsync(j => j.CurrentStage == 12)
            };

            // Aggregations for Charts
            stats.JobsByStage = await query
                .Include(j => j.Status)
                .GroupBy(j => j.Status.StatusName ?? "Unknown")
                .Select(g => new ChartDataPoint { Label = g.Key, Value = g.Count() })
                .ToListAsync();

            stats.JobsByType = await query
                .Include(j => j.JobType)
                .GroupBy(j => j.JobType.Type ?? "Unknown")
                .Select(g => new ChartDataPoint { Label = g.Key, Value = g.Count() })
                .ToListAsync();

            return Ok(stats);
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

                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = $"Job status updated to {status.StatusName} via Bulk Action"
                });
            }

            await _context.SaveChangesAsync();

            // Trigger notifications
            foreach (var job in jobs)
            {
                await _notificationService.NotifyStatusChangeAsync(job.Id, 0, request.StatusId);
            }

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

                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = $"Temporarily assigned to Staff ID {request.StaffId} until {request.UntilDate:yyyy-MM-dd}. Reason: {request.Note}"
                });
            }

            await _context.SaveChangesAsync();
            
            // Trigger notifications
            foreach (var job in jobs)
            {
                await _notificationService.NotifyTemporaryAssignmentAsync(job.Id, request.StaffId, request.UntilDate, request.Note);
            }
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

            if (filter.DeadlineFrom.HasValue) 
                query = query.Where(j => j.Deadline >= filter.DeadlineFrom.Value.Date);
            if (filter.DeadlineTo.HasValue) 
                query = query.Where(j => j.Deadline <= filter.DeadlineTo.Value.Date.AddDays(1).AddTicks(-1));

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
                    CreatedDate = j.CreatedDateTime
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
                    StatusColor = j.Status != null ? j.Status.Color : "gray",
                    StatusIcon = j.Status != null ? j.Status.Icon : null,
                    AssignDate = j.StartDate ?? j.CreatedDateTime,
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
                    IsRecurring = j.IsRecurring,
                    CreatedUserId = j.CreatedUserId,
                    CreatedUserName = _context.Users.Where(u => u.Id == j.CreatedUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    CreatedDateTime = j.CreatedDateTime
                })
                .ToListAsync();

            return Ok(jobs);
        }

        [HttpGet("recurring-history/{id}")]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetRecurringHistory(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            // Find all jobs in the chain. 
            // We traverse up to the root and then collect all descendants.
            var root = job;
            while (root.ParentJobId.HasValue)
            {
                var parent = await _context.Jobs.FindAsync(root.ParentJobId.Value);
                if (parent == null) break;
                root = parent;
            }

            // Now collect all jobs that start from this root
            var chain = new List<Job>();
            chain.Add(root);

            var currentLevel = new List<Job> { root };
            while (currentLevel.Any())
            {
                var nextLevelIds = currentLevel.Select(j => j.Id).ToList();
                var children = await _context.Jobs
                    .Where(j => j.ParentJobId.HasValue && nextLevelIds.Contains(j.ParentJobId.Value))
                    .ToListAsync();
                
                chain.AddRange(children);
                currentLevel = children;
            }

            var results = chain
                .OrderByDescending(j => j.CreatedDateTime)
                .Select(j => new JobDto
                {
                    Id = j.Id,
                    Caption = j.Caption,
                    CurrentStage = j.CurrentStage,
                    StatusName = _context.JobStatusMasters.Where(s => s.ID == j.CurrentStage).Select(s => s.StatusName).FirstOrDefault() ?? "Pending",
                    StatusColor = _context.JobStatusMasters.Where(s => s.ID == j.CurrentStage).Select(s => s.Color).FirstOrDefault() ?? "gray",
                    AssignDate = j.StartDate ?? j.CreatedDateTime,
                    Deadline = j.Deadline,
                    CreatedDateTime = j.CreatedDateTime,
                    Tasks = _context.JobTasks.Where(t => t.JobId == j.Id).OrderBy(t => t.Sequence).Select(t => new JobTaskDto
                    {
                        Id = t.Id,
                        Description = t.Description,
                        IsCompleted = t.IsCompleted
                    }).ToList()
                })
                .ToList();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.Customer)
                    .ThenInclude(c => c.ContactInfo)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .Include(j => j.Tasks.OrderBy(t => t.Sequence))
                .Include(j => j.Comments.OrderByDescending(c => c.CreatedDateTime))
                .Include(j => j.History.OrderByDescending(h => h.CreatedDateTime))
                .FirstOrDefaultAsync(j => j.Id == id);

            if (job == null) return NotFound();

            var dto = new JobDto
            {
                Id = job.Id,
                CustomerId = job.CustomerId,
                CustomerName = job.CustomerId.HasValue ? job.Customer.Name : "Office Schedule",
                CustomerCode = job.CustomerId.HasValue ? job.Customer.Code : null,
                CustomerEmail = job.CustomerId.HasValue && job.Customer.ContactInfo != null ? job.Customer.ContactInfo.Email : null,
                CustomerPhone = job.CustomerId.HasValue && job.Customer.ContactInfo != null ? (job.Customer.ContactInfo.CellPhone ?? job.Customer.ContactInfo.WorkPhone) : null,
                IsInternal = job.IsInternal,
                JobTypeId = job.JobTypeId,
                JobTypeName = job.JobType.Type,
                Caption = job.Caption,
                Description = job.Description,
                Priority = job.Priority,
                CurrentStage = job.CurrentStage,
                StatusName = job.Status != null ? job.Status.StatusName : "Pending",
                StatusColor = job.Status != null ? job.Status.Color : "gray",
                StatusIcon = job.Status != null ? job.Status.Icon : null,
                AssignDate = job.StartDate ?? job.CreatedDateTime,
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
                CreatedUserId = job.CreatedUserId,
                CreatedUserName = _context.Users.Where(u => u.Id == job.CreatedUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                CreatedDateTime = job.CreatedDateTime,
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
                    UserId = c.CreatedUserId ?? 0,
                    UserName = _context.Users.Where(u => u.Id == c.CreatedUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault() ?? "Unknown",
                    Text = c.Text,
                    CreatedDateTime = c.CreatedDateTime
                }).ToList(),
                History = job.History.Select(h => new JobHistoryDto
                {
                    Id = h.Id,
                    JobId = h.JobId,
                    Event = h.Event,
                    UserId = h.CreatedUserId ?? 0,
                    UserName = _context.Users.Where(u => u.Id == h.CreatedUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault() ?? "System",
                    Timestamp = h.CreatedDateTime
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
                IsInternal = dto.IsInternal,
                IsRecurring = dto.IsRecurring,
                CreatedUserId = GetCurrentUserId()
            };

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
                    Sequence = t.Sequence
                }).ToList();
                
                _context.JobTasks.AddRange(tasks);
                await _context.SaveChangesAsync();
            }

                _context.JobHistories.Add(new JobHistory
            {
                JobId = job.Id,
                Event = "Job Created"
            });
            await _context.SaveChangesAsync();

            // Trigger Assignment Notification
            await _notificationService.NotifyAssignmentAsync(job.Id);

            return await GetJob(job.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobCreateUpdateDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            var changes = new List<string>();

            // Capture old values for notification logic
            int previousStatusId = job.CurrentStage ?? 1;
            int? previousResponsibleId = job.ResponsibleId;

            if (job.CurrentStage != dto.CurrentStage)
            {
                var oldStatus = await _context.JobStatusMasters.FindAsync(job.CurrentStage);
                var newStatus = await _context.JobStatusMasters.FindAsync(dto.CurrentStage);
                changes.Add($"changed status from '{oldStatus?.StatusName ?? "Pending"}' to '{newStatus?.StatusName ?? "Unknown"}'");
            }
            if (job.Priority != dto.Priority) 
                changes.Add($"changed priority to {(dto.Priority == 1 ? "Low" : dto.Priority == 2 ? "Medium" : dto.Priority == 3 ? "High" : "Urgent")}");
            if (job.Deadline != dto.Deadline) 
                changes.Add($"updated Deadline to {dto.Deadline?.ToString("MMM dd, yyyy") ?? "None"}");
            if (job.StartDate != dto.StartDate) 
                changes.Add($"updated Start Date to {dto.StartDate?.ToString("MMM dd, yyyy") ?? "None"}");
            if (job.Caption != dto.Caption) 
                changes.Add($"updated Title");
            
            job.JobTypeId = dto.JobTypeId;
            job.Caption = dto.Caption!;
            job.Description = dto.Description;
            job.Priority = dto.Priority;
            job.CurrentStage = dto.CurrentStage;
            job.StartDate = dto.StartDate;
            job.Deadline = dto.Deadline;
            job.OwnerId = dto.OwnerId;
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
                changes.Add("reassigned Job");
                job.ResponsibleId = dto.ResponsibleId;
                job.OriginalResponsibleId = null;
                job.TemporaryAssignmentUntil = null;
                job.TemporaryAssignmentNote = null;
            }
            
            job.UpdateDateTime = DateTime.Now;
            var currentUserId = GetCurrentUserId();
            if (currentUserId.HasValue)
            {
                job.UpdateUserId = currentUserId;
            }

            if (changes.Any())
            {
                _context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = string.Join(", ", changes),
                    CreatedUserId = currentUserId,
                    CreatedDateTime = DateTime.Now
                });
            }

            // Trigger Notifications after saving
            int currentStatusId = job.CurrentStage ?? 1;
            bool statusChanged = previousStatusId != currentStatusId;
            bool assignedChanged = previousResponsibleId != job.ResponsibleId;

            await _context.SaveChangesAsync();

            if (statusChanged)
            {
                await _notificationService.NotifyStatusChangeAsync(job.Id, previousStatusId, currentStatusId);
            }
            if (assignedChanged)
            {
                await _notificationService.NotifyAssignmentAsync(job.Id, previousResponsibleId);
            }

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
                Sequence = taskCount + 1
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
                Text = text
            };

            _context.JobComments.Add(comment);
            await _context.SaveChangesAsync();

            // Trigger Comment Notification
            await _notificationService.NotifyCommentAsync(id, comment.Id);

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
                CreatedDateTime = comment.CreatedDateTime
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

            int oldStatusId = job.CurrentStage ?? 0;
            job.CurrentStage = 12; // Completed
            job.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            // Trigger notification
            await _notificationService.NotifyStatusChangeAsync(job.Id, oldStatusId, 12);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ArchiveJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();

            // Permission Check: Admin or Owner
            var currentUserId = GetCurrentUserId();
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            bool isAdmin = roles.Contains("SuperAdmin") || roles.Contains("Admin");

            if (!isAdmin && job.OwnerId != currentUserId)
            {
                return Forbid("Only Admins or the Job Owner can archive this job.");
            }

            // Capture info before archiving for notification
            int jobId = job.Id;

            // Trigger "Job Archived" notification
            await _notificationService.NotifyStatusChangeAsync(jobId, job.CurrentStage ?? 0, 99);

            job.IsActive = false;
            job.UpdateUserId = currentUserId;
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

            var currentUserId = GetCurrentUserId();
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            bool isAdmin = roles.Contains("SuperAdmin") || roles.Contains("Admin");

            var jobs = await _context.Jobs.Where(j => jobIds.Contains(j.Id)).ToListAsync();
            
            int archivedCount = 0;
            foreach (var job in jobs)
            {
                // In bulk, we skip ones we don't have permission for if not admin
                if (!isAdmin && job.OwnerId != currentUserId) continue;

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
                archivedCount++;
            }

            await _context.SaveChangesAsync();

            // Trigger notifications for each archived job
            foreach (var job in jobs)
            {
                if (!isAdmin && job.OwnerId != currentUserId) continue; // Safety check
                await _notificationService.NotifyStatusChangeAsync(job.Id, 0, 99);
            }

            return Ok(new { success = true, count = archivedCount });
        }
    }
}
