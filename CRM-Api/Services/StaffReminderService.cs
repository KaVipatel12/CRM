using CRM_Api.Data;
using CRM_Api.Models;
using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class StaffReminderService : IStaffReminderService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public StaffReminderService(
            AppDbContext context,
            IEmailService emailService,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<int> SendAllStaffOverdueRemindersAsync()
        {
            var now = DateTime.Now;
            int emailsSent = 0;

            // 1. Fetch all overdue jobs with related data
            var overdueJobs = await _context.Jobs
                .Include(j => j.JobType)
                .Include(j => j.Customer)
                .Where(j => j.IsActive && j.CurrentStage != 6 && (j.Deadline != null && j.Deadline.Value.Date < now.Date || j.Priority == 3))
                .ToListAsync();

            if (!overdueJobs.Any()) return 0;

            // 2. Identify all people who need to be notified (Responsible and Temp Assignees)
            var staffToNotify = new Dictionary<int, List<CRM_Api.Models.Entities.Operations.Job>>();

            foreach (var job in overdueJobs)
            {
                // Primary Responsible Person
                if (job.ResponsibleId.HasValue)
                {
                    AddJobToStaffList(staffToNotify, job.ResponsibleId.Value, job);
                }

                // Temporary Assignee (if applicable)
                if (job.TemporaryAssignmentUntil.HasValue && job.TemporaryAssignmentUntil.Value >= now)
                {
                    // Assuming we have a way to track who the temp assignee is 
                    // In your schema, it seems ResponsibleId IS updated when temporary assignment happens, 
                    // and OriginalResponsibleId stores the old one.
                }
            }

            // 3. Loop through each staff member and send their summary
            string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";

            foreach (var staffId in staffToNotify.Keys)
            {
                var user = await _userManager.FindByIdAsync(staffId.ToString());
                if (user == null || string.IsNullOrEmpty(user.Email)) continue;

                var jobs = staffToNotify[staffId];
                string subject = $"Action Required: You have {jobs.Count} Overdue Jobs";
                string title = "Your Overdue Jobs Summary";

                // Build Table Rows
                var tableRows = string.Join("", jobs.Select(j => $@"
                    <tr>
                        <td style='padding: 10px; border-bottom: 1px solid #e5e7eb; color: #374151; font-size: 14px;'>{j.Customer?.Name ?? "N/A"}</td>
                        <td style='padding: 10px; border-bottom: 1px solid #e5e7eb; color: #374151; font-size: 14px;'>{j.JobType?.Type ?? "Job"}</td>
                        <td style='padding: 10px; border-bottom: 1px solid #e5e7eb; color: #ef4444; font-size: 14px; font-weight: bold;'>{j.Deadline:dd MMM yyyy}</td>
                    </tr>"));

                string body = $@"
                    <p style='color: #4b5563; font-size: 16px;'>Hello {user.UserName},</p>
                    <p style='color: #4b5563; font-size: 16px;'>You have <strong>{jobs.Count}</strong> jobs that are currently past their deadline. Please review them as soon as possible.</p>
                    
                    <table width='100%' cellpadding='0' cellspacing='0' style='margin-top: 20px; border: 1px solid #e5e7eb; border-radius: 6px; border-collapse: collapse;'>
                        <thead>
                            <tr style='background-color: #f9fafb;'>
                                <th align='left' style='padding: 10px; border-bottom: 2px solid #e5e7eb; color: #111827; font-size: 13px;'>Customer</th>
                                <th align='left' style='padding: 10px; border-bottom: 2px solid #e5e7eb; color: #111827; font-size: 13px;'>Job Type</th>
                                <th align='left' style='padding: 10px; border-bottom: 2px solid #e5e7eb; color: #111827; font-size: 13px;'>Deadline</th>
                            </tr>
                        </thead>
                        <tbody>
                            {tableRows}
                        </tbody>
                    </table>

                    <div style='text-align: center; margin-top: 30px;'>
                        <a href='{dashboardUrl}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                            Open My Job List
                        </a>
                    </div>";

                await _emailService.SendEmailAsync(user.Email, subject, body, title);
                emailsSent++;
            }

            return emailsSent;
        }

        private void AddJobToStaffList(Dictionary<int, List<CRM_Api.Models.Entities.Operations.Job>> dict, int staffId, CRM_Api.Models.Entities.Operations.Job job)
        {
            if (!dict.ContainsKey(staffId))
            {
                dict[staffId] = new List<CRM_Api.Models.Entities.Operations.Job>();
            }
            dict[staffId].Add(job);
        }
    }
}
