using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class AdminReminderService : IAdminReminderService
    {
        private readonly IEmailService _emailService;
        private readonly CRM_Api.Data.AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminReminderService(IEmailService emailService, CRM_Api.Data.AppDbContext context, IConfiguration configuration)
        {
            _emailService = emailService;
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> SendDailyAdminReminderAsync(string adminEmail)
        {
            string subject = $"Daily Admin Reminder - {DateTime.Now:dd/MM/yyyy}";
            string title = "Daily Checklist";

            string body = $@"
                <p style='color: #4b5563; font-size: 16px;'>Hello Admin, here are your tasks and reminders for today:</p>
                
                <ul style='padding-left: 20px; color: #374151;'>
                    <li style='margin-bottom: 12px;'>
                        <strong style='color: #0d9488;'>ASIC Portal:</strong> 
                        Please check the ASIC portal and review the invoices.
                    </li>
                    <li style='margin-bottom: 12px;'>
                        <strong style='color: #0d9488;'>Overdue Jobs:</strong> 
                        Please follow up on the overdue Job Reminder email from SSP CRM.
                    </li>
                    <li style='margin-bottom: 12px;'>
                        <strong style='color: #0d9488;'>Potential Clients:</strong> 
                        Please follow up any potential leads or prospects.
                    </li>
                    <li style='margin-bottom: 12px;'>
                        <strong style='color: #0d9488;'>Call Tracker:</strong> 
                        Please check the call tracker and take action if needed.
                    </li>
                    <li style='margin-bottom: 12px;'>
                        <strong style='color: #0d9488;'>Team Management:</strong> 
                        Please follow up with the responsible person for any jobs lagging behind.
                    </li>
                </ul>

                <div style='margin-top: 30px; padding: 15px; background-color: #f0fdfa; border-left: 4px solid #0d9488; font-style: italic; color: #0f766e;'>
                    Reminder: These tasks are part of the daily operational requirements to ensure smooth client management.
                </div>
                
                <p style='margin-top: 25px; color: #6b7280; font-size: 14px;'>Have a productive day!</p>";

            try
            {
                await _emailService.SendEmailAsync(adminEmail, subject, body, title);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendOverdueJobReminderAsync(string adminEmail)
        {
            var now = DateTime.Now;
            
            // Fetch overdue jobs:
            // 1. Deadline has passed
            // OR 2. Priority is explicitly set to 3 (Overdue)
            // AND 3. Status is not Completed (6)
            var overdueJobs = await _context.Jobs
                .Include(j => j.JobType)
                .Where(j => j.IsActive && j.CurrentStage != 6 && (j.Deadline != null && j.Deadline.Value.Date < now.Date || j.Priority == 3))
                .ToListAsync();

            if (!overdueJobs.Any())
            {
                return true; // No overdue jobs to report
            }

            // Group by Job Type for the summary table
            var summary = overdueJobs
                .GroupBy(j => j.JobType != null ? j.JobType.Type : "Other")
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            string title = "Overdue Job Report";
            string subject = $"Overdue Jobs Alert - {now:dd/MM/yyyy}";
            string dashboardUrl = _configuration["DashboardUrl"] ?? "http://localhost:4200/admin/jobs";

            // Build the HTML Table Rows
            var tableRows = string.Join("", summary.Select(s => $@"
                <tr>
                    <td style='padding: 12px; border-bottom: 1px solid #e5e7eb; color: #374151;'>{s.Type}</td>
                    <td style='padding: 12px; border-bottom: 1px solid #e5e7eb; color: #ef4444; font-weight: bold; text-align: center;'>{s.Count}</td>
                </tr>"));

            string body = $@"
                <p style='color: #4b5563; font-size: 16px;'>The following jobs have exceeded their deadlines and require immediate attention:</p>
                
                <table width='100%' cellpadding='0' cellspacing='0' style='margin-top: 20px; border: 1px solid #e5e7eb; border-radius: 6px; overflow: hidden; border-collapse: collapse;'>
                    <thead>
                        <tr style='background-color: #f9fafb;'>
                            <th align='left' style='padding: 12px; border-bottom: 2px solid #e5e7eb; color: #111827;'>Job Type</th>
                            <th align='center' style='padding: 12px; border-bottom: 2px solid #e5e7eb; color: #111827;'>Total Overdue</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableRows}
                    </tbody>
                </table>

                <div style='text-align: center; margin-top: 30px; margin-bottom: 30px;'>
                    <a href='{dashboardUrl}' style='background-color: #0d9488; color: white; padding: 12px 25px; text-decoration: none; border-radius: 6px; font-weight: bold; display: inline-block;'>
                        View All Overdue Jobs in Dashboard
                    </a>
                </div>

                <div style='margin-top: 25px; padding: 15px; background-color: #fffaf0; border-left: 4px solid #f59e0b; color: #92400e; font-size: 14px;'>
                    <strong>Action Required:</strong> Please coordinate with the responsible team members to resolve these pending tasks as soon as possible.
                </div>";

            try
            {
                await _emailService.SendEmailAsync(adminEmail, subject, body, title);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
