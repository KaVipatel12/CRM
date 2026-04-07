using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Include(j => j.Status)
                .OrderByDescending(j => j.UpdateDateTime)
                .Select(j => new JobDto
                {
                    Id = j.Id,
                    CustomerId = j.CustomerId,
                    CustomerName = j.Customer.Name,
                    JobTypeId = j.JobTypeId,
                    JobTypeName = j.JobType.Type,
                    Caption = j.Caption,
                    Description = j.Description,
                    Priority = j.Priority,
                    CurrentStage = j.CurrentStage,
                    StatusName = j.Status != null ? j.Status.StatusName : "Pending",
                    StartDate = j.StartDate,
                    Deadline = j.Deadline,
                    OwnerId = j.OwnerId,
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
                    CustomerName = j.Customer.Name,
                    JobTypeId = j.JobTypeId,
                    JobTypeName = j.JobType.Type,
                    Caption = j.Caption,
                    Description = j.Description,
                    Priority = j.Priority,
                    CurrentStage = j.CurrentStage,
                    StatusName = j.Status != null ? j.Status.StatusName : "Pending",
                    StartDate = j.StartDate,
                    Deadline = j.Deadline,
                    OwnerId = j.OwnerId,
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
                CustomerName = job.Customer.Name,
                JobTypeId = job.JobTypeId,
                JobTypeName = job.JobType.Type,
                Caption = job.Caption,
                Description = job.Description,
                Priority = job.Priority,
                CurrentStage = job.CurrentStage,
                StatusName = job.Status != null ? job.Status.StatusName : "Pending",
                StartDate = job.StartDate,
                Deadline = job.Deadline,
                OwnerId = job.OwnerId,
                Period = job.Period,
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
                Caption = dto.Caption,
                Description = dto.Description,
                Priority = dto.Priority,
                CurrentStage = dto.CurrentStage ?? 1, // Default to first stage
                StartDate = dto.StartDate,
                Deadline = dto.Deadline,
                OwnerId = dto.OwnerId,
                Period = dto.Period,
                TargetEndDate = dto.TargetEndDate,
                DueDateDays = dto.DueDateDays,
                DueDateBasis = dto.DueDateBasis,
                IsActive = true,
                IsRecurring = dto.IsRecurring,
                CreatedDate = DateTime.Now
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
                UserId = 0 // Placeholder for User context
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
            job.Caption = dto.Caption;
            job.Description = dto.Description;
            job.Priority = dto.Priority;
            job.CurrentStage = dto.CurrentStage;
            job.StartDate = dto.StartDate;
            job.Deadline = dto.Deadline;
            job.OwnerId = dto.OwnerId;
            job.Period = dto.Period;
            job.TargetEndDate = dto.TargetEndDate;
            job.DueDateDays = dto.DueDateDays;
            job.DueDateBasis = dto.DueDateBasis;
            job.IsRecurring = dto.IsRecurring;
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

            var comment = new JobComment
            {
                JobId = id,
                Text = text,
                CreatedAt = DateTime.Now
            };

            _context.JobComments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new JobCommentDto
            {
                Id = comment.Id,
                JobId = comment.JobId,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt
            });
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
    }
}
