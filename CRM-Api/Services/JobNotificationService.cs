using CRM_Api.Data;
using CRM_Api.Models;
using CRM_Api.Models.Entities.Operations;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class JobNotificationService : IJobNotificationService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<JobNotificationService> _logger;

        public JobNotificationService(
            IServiceScopeFactory scopeFactory,
            IEmailService emailService,
            IConfiguration configuration,
            ILogger<JobNotificationService> logger)
        {
            _scopeFactory = scopeFactory;
            _emailService = emailService;
            _configuration = configuration;
            _logger = logger;
        }

        public Task NotifyAssignmentAsync(int jobId, int? previousResponsibleId = null)
        {
            _logger.LogInformation("Queuing assignment notification for Job ID: {JobId}", jobId);
            _ = Task.Run(async () =>
            {
                try 
                {
                    using var scope = _scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    var job = await context.Jobs
                        .Include(j => j.Customer)
                        .Include(j => j.JobType)
                        .Include(j => j.Status)
                        .FirstOrDefaultAsync(j => j.Id == jobId);

                    if (job == null) 
                    {
                        _logger.LogWarning("Job not found for assignment notification: {JobId}", jobId);
                        return;
                    }

                    _logger.LogInformation("Processing assignment notification for Job: {Caption} (ID: {JobId})", job.Caption, jobId);

                    // Get the person who assigned the job (Current user who updated/created it)
                    int? assignerId = job.UpdateUserId ?? job.CreatedUserId;
                    string assignerName = "System";
                    if (assignerId.HasValue)
                    {
                        var assigner = await userManager.FindByIdAsync(assignerId.Value.ToString());
                        if (assigner != null) assignerName = $"{assigner.FirstName} {assigner.LastName}";
                    }

                    string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";
                    string customerName = job.Customer?.Name ?? "Internal Operation";
                    string jobTypeName = job.JobType?.Type ?? "Task";

                    // 1. Notify Responsible Person
                    if (job.ResponsibleId.HasValue && job.ResponsibleId != assignerId) // Don't notify if I assign to myself
                    {
                        var responsible = await userManager.FindByIdAsync(job.ResponsibleId.Value.ToString());
                        if (responsible != null && !string.IsNullOrEmpty(responsible.Email))
                        {
                            _logger.LogInformation("Sending assignment email to Responsible: {Email}", responsible.Email);
                            string subject = $"New Job Assigned: {jobTypeName} - {customerName}";
                            string title = "Job Assignment Alert";
                            string body = $@"
                                <p style='color: #4b5563; font-size: 16px;'>Hello {responsible.FirstName},</p>
                                <p style='color: #4b5563; font-size: 16px;'>You have been <strong>assigned</strong> to the following job:</p>
                                
                                <div style='background-color: #f9fafb; padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #e5e7eb;'>
                                    <p style='margin: 5px 0;'><strong>Customer:</strong> {customerName}</p>
                                    <p style='margin: 5px 0;'><strong>Job Type:</strong> {jobTypeName}</p>
                                    <p style='margin: 5px 0;'><strong>Deadline:</strong> {job.Deadline:dd MMM yyyy}</p>
                                    <p style='margin: 5px 0; color: #0d9488;'><strong>Assigned By:</strong> {assignerName}</p>
                                </div>

                                <div style='text-align: center; margin-top: 30px;'>
                                    <a href='{dashboardUrl}/{job.Id}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                                        View Job Details
                                    </a>
                                </div>";

                            await emailService.SendEmailAsync(responsible.Email!, subject, body, title);
                        }
                    }

                    // 2. Notify Owner (Lead/Observer)
                    if (job.OwnerId.HasValue && job.OwnerId != job.ResponsibleId && job.OwnerId != assignerId)
                    {
                        var owner = await userManager.FindByIdAsync(job.OwnerId.Value.ToString());
                        if (owner != null && !string.IsNullOrEmpty(owner.Email))
                        {
                            _logger.LogInformation("Sending assignment email to Owner: {Email}", owner.Email);
                            string subject = $"New Job Lead: {jobTypeName} - {customerName}";
                            string title = "Job Observation Alert";
                            string body = $@"
                                <p style='color: #4b5563; font-size: 16px;'>Hello {owner.FirstName},</p>
                                <p style='color: #4b5563; font-size: 16px;'>You have been designated as the <strong>Lead/Observer</strong> for this job:</p>
                                
                                <div style='background-color: #f9fafb; padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #e5e7eb;'>
                                    <p style='margin: 5px 0;'><strong>Customer:</strong> {customerName}</p>
                                    <p style='margin: 5px 0;'><strong>Job Type:</strong> {jobTypeName}</p>
                                    <p style='margin: 5px 0;'><strong>Responsible:</strong> {(job.UpdateUserId == job.ResponsibleId ? "Self" : "Assigned to Staff")}</p>
                                    <p style='margin: 5px 0; color: #0d9488;'><strong>Initiated By:</strong> {assignerName}</p>
                                </div>

                                <div style='text-align: center; margin-top: 30px;'>
                                    <a href='{dashboardUrl}/{job.Id}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                                        Open Dashboard
                                    </a>
                                </div>";

                            await emailService.SendEmailAsync(owner.Email!, subject, body, title);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing assignment notification for Job ID: {JobId}", jobId);
                }
            });

            return Task.CompletedTask;
        }

        public Task NotifyTemporaryAssignmentAsync(int jobId, int temporaryAssigneeId, DateTime untilDate, string note)
        {
            _logger.LogInformation("Queuing temporary assignment notification for Job ID: {JobId}", jobId);
            _ = Task.Run(async () =>
            {
                try 
                {
                    using var scope = _scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    var job = await context.Jobs
                        .Include(j => j.Customer)
                        .Include(j => j.JobType)
                        .Include(j => j.Status)
                        .FirstOrDefaultAsync(j => j.Id == jobId);

                    if (job == null) return;

                    var tempAssignee = await userManager.FindByIdAsync(temporaryAssigneeId.ToString());
                    if (tempAssignee == null) return;

                    // Get the person who initiated the change
                    int? updaterId = job.UpdateUserId ?? job.CreatedUserId;
                    string updaterName = "System";
                    if (updaterId.HasValue)
                    {
                        var updater = await userManager.FindByIdAsync(updaterId.Value.ToString());
                        if (updater != null) updaterName = $"{updater.FirstName} {updater.LastName}";
                    }

                    string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";
                    string customerName = job.Customer?.Name ?? "Internal Operation";
                    string jobTypeName = job.JobType?.Type ?? "Task";
                    string untilStr = untilDate.ToString("dd MMM yyyy");

                    // 1. Identify all recipients
                    var recipients = new List<User> { tempAssignee };

                    // Add Original Responsible (the person being covered)
                    if (job.OriginalResponsibleId.HasValue)
                    {
                        var resp = await userManager.FindByIdAsync(job.OriginalResponsibleId.Value.ToString());
                        if (resp != null) recipients.Add(resp);
                    }

                    // Add Owner
                    if (job.OwnerId.HasValue)
                    {
                        var own = await userManager.FindByIdAsync(job.OwnerId.Value.ToString());
                        if (own != null) recipients.Add(own);
                    }

                    // Filter unique emails
                    var uniqueRecipients = recipients
                        .Where(r => r != null && !string.IsNullOrEmpty(r.Email))
                        .GroupBy(r => r.Email)
                        .Select(g => g.First())
                        .ToList();

                    foreach (var user in uniqueRecipients)
                    {
                        string subject = $"Temporary Assignment: {jobTypeName} - {customerName}";
                        string title = "Temporary Coverage Alert";
                        
                        string body = $@"
                            <p style='color: #4b5563; font-size: 16px;'>Hello {user.FirstName},</p>
                            <p style='color: #4b5563; font-size: 16px;'>A <strong>temporary assignment</strong> has been set for the following job:</p>
                            
                            <div style='background-color: #f0fdfa; padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #ccfbf1; color: #115e59;'>
                                <p style='margin: 5px 0;'><strong>Customer:</strong> {customerName}</p>
                                <p style='margin: 5px 0;'><strong>Job:</strong> {jobTypeName}</p>
                                <p style='margin: 5px 0;'><strong>Temporary Assignee:</strong> {tempAssignee.FirstName} {tempAssignee.LastName}</p>
                                <p style='margin: 5px 0;'><strong>Covering Until:</strong> {untilStr}</p>
                                <p style='margin: 5px 0; font-size: 14px; font-style: italic;'><strong>Note:</strong> {note}</p>
                            </div>

                            <p style='font-size: 13px; color: #6b7280;'>This change was initiated by {updaterName}.</p>

                            <div style='text-align: center; margin-top: 30px;'>
                                <a href='{dashboardUrl}/{job.Id}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                                    View Job Details
                                </a>
                            </div>";

                        await emailService.SendEmailAsync(user.Email!, subject, body, title);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing temporary assignment notification for Job ID: {JobId}", jobId);
                }
            });

            return Task.CompletedTask;
        }

        public async Task ProcessExpiredTemporaryAssignmentsAsync()
        {
            _logger.LogInformation("Checking for expired temporary assignments...");
            
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var now = DateTime.Now;
            var expiredJobs = await context.Jobs
                .Include(j => j.Customer)
                .Include(j => j.JobType)
                .Where(j => j.TemporaryAssignmentUntil != null && j.TemporaryAssignmentUntil < now && j.OriginalResponsibleId != null)
                .ToListAsync();

            _logger.LogInformation("Found {Count} expired temporary assignments to revert.", expiredJobs.Count);

            foreach (var job in expiredJobs)
            {
                int? tempAssigneeId = job.ResponsibleId;
                int? originalResponsibleId = job.OriginalResponsibleId;
                
                // Revert
                job.ResponsibleId = job.OriginalResponsibleId;
                job.OriginalResponsibleId = null;
                job.TemporaryAssignmentUntil = null;
                job.TemporaryAssignmentNote = null;

                context.JobHistories.Add(new JobHistory
                {
                    JobId = job.Id,
                    Event = "Temporary Assignment Ended. Job returned to original staff."
                });

                // Notify parties
                var recipients = new List<User>();
                User? originalResp = null;

                if (originalResponsibleId.HasValue)
                {
                    originalResp = await userManager.FindByIdAsync(originalResponsibleId.Value.ToString());
                    if (originalResp != null) recipients.Add(originalResp);
                }
                if (tempAssigneeId.HasValue)
                {
                    var tempStaff = await userManager.FindByIdAsync(tempAssigneeId.Value.ToString());
                    if (tempStaff != null) recipients.Add(tempStaff);
                }
                if (job.OwnerId.HasValue)
                {
                    var own = await userManager.FindByIdAsync(job.OwnerId.Value.ToString());
                    if (own != null) recipients.Add(own);
                }

                var uniqueRecipients = recipients
                    .Where(r => r != null && !string.IsNullOrEmpty(r.Email))
                    .GroupBy(r => r.Email)
                    .Select(g => g.First())
                    .ToList();

                string customerName = job.Customer?.Name ?? "Internal Operation";
                string jobTypeName = job.JobType?.Type ?? "Task";
                string originalRespName = originalResp != null ? $"{originalResp.FirstName} {originalResp.LastName}" : "Original Staff";

                foreach (var user in uniqueRecipients)
                {
                    string subject = $"Coverage Ended: {jobTypeName} - {customerName}";
                    string title = "Temporary Assignment Ended";
                    
                    string body = $@"
                        <p style='color: #4b5563; font-size: 16px;'>Hello {user.FirstName},</p>
                        <p style='color: #4b5563; font-size: 16px;'>The temporary coverage period has <strong>ended</strong> for this job:</p>
                        
                        <div style='background-color: #f8fafc; padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #e2e8f0; color: #1e293b;'>
                            <p style='margin: 5px 0;'><strong>Customer:</strong> {customerName}</p>
                            <p style='margin: 5px 0;'><strong>Job:</strong> {jobTypeName}</p>
                            <p style='margin: 5px 0; color: #0d9488;'><strong>Status:</strong> Returned to {originalRespName}</p>
                        </div>

                        <p style='font-size: 14px; color: #6b7280;'>The job has been automatically reassigned to its primary responsible staff member.</p>";

                    await emailService.SendEmailAsync(user.Email!, subject, body, title);
                }
            }

            if (expiredJobs.Any())
            {
                await context.SaveChangesAsync();
                _logger.LogInformation("Successfully reverted and notified for {Count} expired jobs.", expiredJobs.Count);
            }
        }

        public Task NotifyCommentAsync(int jobId, int commentId)
        {
            _logger.LogInformation("Queuing comment notification for Job ID: {JobId}, Comment ID: {CommentId}", jobId, commentId);
            _ = Task.Run(async () =>
            {
                try 
                {
                    using var scope = _scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    var job = await context.Jobs
                        .Include(j => j.Customer)
                        .Include(j => j.JobType)
                        .FirstOrDefaultAsync(j => j.Id == jobId);

                    if (job == null) return;

                    var comment = await context.JobComments
                        .FirstOrDefaultAsync(c => c.Id == commentId);

                    if (comment == null) return;

                    string commenterName = "Staff";
                    var commenterUser = await userManager.FindByIdAsync(comment.UserId.ToString());
                    if (commenterUser != null) commenterName = $"{commenterUser.FirstName} {commenterUser.LastName}";
                    string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";
                    string customerName = job.Customer?.Name ?? "Internal Operation";
                    string jobTypeName = job.JobType?.Type ?? "Task";

                    // 1. Identify all potential recipients
                    var recipients = new List<User>();

                    // Add Responsible
                    if (job.ResponsibleId.HasValue)
                    {
                        var resp = await userManager.FindByIdAsync(job.ResponsibleId.Value.ToString());
                        if (resp != null) recipients.Add(resp);
                    }

                    // Add Original Responsible (if covered)
                    if (job.OriginalResponsibleId.HasValue)
                    {
                        var orig = await userManager.FindByIdAsync(job.OriginalResponsibleId.Value.ToString());
                        if (orig != null) recipients.Add(orig);
                    }

                    // Add Owner
                    if (job.OwnerId.HasValue)
                    {
                        var own = await userManager.FindByIdAsync(job.OwnerId.Value.ToString());
                        if (own != null) recipients.Add(own);
                    }

                    // Filter unique recipients and exclude the commenter
                    var uniqueRecipients = recipients
                        .Where(r => r != null && !string.IsNullOrEmpty(r.Email))
                        .GroupBy(r => r.Email)
                        .Select(g => g.First())
                        .Where(r => r.Id != comment.UserId)
                        .ToList();

                    foreach (var user in uniqueRecipients)
                    {
                        string subject = $"New Comment: {jobTypeName} - {customerName}";
                        string title = "Job Comment Added";
                        
                        string body = $@"
                            <p style='color: #4b5563; font-size: 16px;'>Hello {user.FirstName},</p>
                            <p style='color: #4b5563; font-size: 16px;'>A new comment has been added to the following job:</p>
                            
                            <div style='background-color: #f3f4f6; padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #e5e7eb;'>
                                <p style='margin: 0 0 10px 0; color: #111827; font-weight: 600;'>{commenterName} wrote:</p>
                                <p style='margin: 0; color: #374151; font-style: italic;'>""{comment.Text}""</p>
                            </div>

                            <div style='background-color: #f9fafb; padding: 10px; border-radius: 6px; font-size: 13px; color: #6b7280;'>
                                <strong>Job:</strong> {jobTypeName} - {customerName}
                            </div>

                            <div style='text-align: center; margin-top: 30px;'>
                                <a href='{dashboardUrl}/{job.Id}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                                    View Conversation
                                </a>
                            </div>";

                        await emailService.SendEmailAsync(user.Email!, subject, body, title);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing comment notification for Job ID: {JobId}", jobId);
                }
            });

            return Task.CompletedTask;
        }

        public Task NotifyStatusChangeAsync(int jobId, int oldStatusId, int newStatusId)
        {
            _logger.LogInformation("Queuing status change notification for Job ID: {JobId} (New Status: {NewStatusId})", jobId, newStatusId);
            _ = Task.Run(async () =>
            {
                try 
                {
                    using var scope = _scopeFactory.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    var job = await context.Jobs
                        .Include(j => j.Customer)
                        .Include(j => j.JobType)
                        .Include(j => j.Status)
                        .FirstOrDefaultAsync(j => j.Id == jobId);

                    if (job == null) 
                    {
                        _logger.LogWarning("Job not found for status change notification: {JobId}", jobId);
                        return;
                    }

                    _logger.LogInformation("Processing status change notification for Job: {Caption} (ID: {JobId})", job.Caption, jobId);

                    // Get the person who updated the status
                    int? updaterId = job.UpdateUserId ?? job.CreatedUserId;
                    string updaterInfo = "System";
                    if (updaterId.HasValue)
                    {
                        var updater = await userManager.FindByIdAsync(updaterId.Value.ToString());
                        if (updater != null) updaterInfo = $"{updater.FirstName} {updater.LastName} ({updater.Email})";
                    }

                    string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";
                    string customerName = job.Customer?.Name ?? "Internal Operation";
                    string jobTypeName = job.JobType?.Type ?? "Task";
                    string newStatusName = newStatusId == 99 ? "Archived" : (job.Status?.StatusName ?? "Updated");

                    // 1. Identify all recipients
                    var recipients = new List<User>();

                    // Add Responsible and Owner
                    if (job.ResponsibleId.HasValue)
                    {
                        var resp = await userManager.FindByIdAsync(job.ResponsibleId.Value.ToString());
                        if (resp != null) recipients.Add(resp);
                    }
                    if (job.OwnerId.HasValue)
                    {
                        var own = await userManager.FindByIdAsync(job.OwnerId.Value.ToString());
                        if (own != null) recipients.Add(own);
                    }

                    // If "Ready for Check", also add all Checkers and Admins
                    if (newStatusId == 5) 
                    {
                        var checkers = await userManager.GetUsersInRoleAsync("Checker");
                        var admins = await userManager.GetUsersInRoleAsync("Admin");
                        var superAdmins = await userManager.GetUsersInRoleAsync("SuperAdmin");
                        recipients.AddRange(checkers);
                        recipients.AddRange(admins);
                        recipients.AddRange(superAdmins);
                    }
                    
                    // Filter unique emails and remove the updater themselves
                    var uniqueRecipients = recipients
                        .Where(r => r != null && !string.IsNullOrEmpty(r.Email))
                        .GroupBy(r => r.Email)
                        .Select(g => g.First())
                        .Where(r => r.Id != updaterId)
                        .ToList();

                    foreach (var user in uniqueRecipients)
                    {
                        string subject = newStatusId == 99 
                            ? $"Job Archived: {jobTypeName} - {customerName}" 
                            : $"Status Updated: {jobTypeName} - {customerName}";
                        
                        string title = newStatusId == 99 ? "Job Archived" : "Job Status Update";
                        
                        // Customize content if it's Ready for Review or Archived
                        string alertStyle = "background-color: #f9fafb; border-left: 4px solid #0d9488; color: #374151;";
                        if (newStatusId == 5) alertStyle = "background-color: #fffaf0; border-left: 4px solid #f59e0b; color: #92400e;";
                        if (newStatusId == 99) alertStyle = "background-color: #fef2f2; border-left: 4px solid #ef4444; color: #991b1b;";

                        string actionText = "The status has been updated";
                        if (newStatusId == 5) actionText = "Action Required: Review this job";
                        if (newStatusId == 99) actionText = "Note: This job has been moved to archive and is no longer active.";

                        string body = $@"
                            <p style='color: #4b5563; font-size: 16px;'>Hello {user.FirstName},</p>
                            <p style='color: #4b5563; font-size: 16px;'>The following job has moved to <strong>{newStatusName}</strong>:</p>
                            
                            <div style='padding: 15px; border-radius: 6px; margin: 20px 0; border: 1px solid #e5e7eb; {alertStyle}'>
                                <p style='margin: 5px 0;'><strong>Customer:</strong> {customerName}</p>
                                <p style='margin: 5px 0;'><strong>Job Type:</strong> {jobTypeName}</p>
                                <p style='margin: 5px 0;'><strong>New Status:</strong> {newStatusName}</p>
                                <p style='margin: 5px 0; font-size: 13px;'><strong>Updated By:</strong> {updaterInfo}</p>
                            </div>

                            <p style='font-style: italic; font-size: 14px; color: #6b7280;'>{actionText}</p>

                            <div style='text-align: center; margin-top: 30px;'>
                                <a href='{dashboardUrl}/{job.Id}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                                    View Job Details
                                </a>
                            </div>";

                        await emailService.SendEmailAsync(user.Email!, subject, body, title);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing status change notification for Job ID: {JobId}", jobId);
                }
            });

            return Task.CompletedTask;
        }
    }
}
