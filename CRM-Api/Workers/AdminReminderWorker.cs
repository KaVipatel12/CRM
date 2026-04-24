using CRM_Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace CRM_Api.Workers
{
    public class AdminReminderWorker : BackgroundService
    {
        private readonly ILogger<AdminReminderWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public AdminReminderWorker(
            ILogger<AdminReminderWorker> logger,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Admin Reminder Background Worker starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var reminderSettings = _configuration.GetSection("ReminderSettings");
                    string dailyTimeStr = reminderSettings["DailyReminderTime"] ?? "08:00:00";
                    string timezoneId = reminderSettings["TimezoneId"] ?? "AUS Eastern Standard Time";

                    // Handle cross-platform timezone IDs (Windows vs Linux)
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && timezoneId == "AUS Eastern Standard Time")
                    {
                        timezoneId = "Australia/Sydney";
                    }

                    var ausTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
                    var nowInAus = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ausTimeZone);

                    if (!TimeSpan.TryParse(dailyTimeStr, out TimeSpan targetTime))
                    {
                        targetTime = new TimeSpan(8, 0, 0); 
                    }

                    var nextRunInAus = nowInAus.Date.Add(targetTime);

                    if (nowInAus > nextRunInAus)
                    {
                        nextRunInAus = nextRunInAus.AddDays(1);
                    }

                    var delay = nextRunInAus - nowInAus;
                    _logger.LogInformation("Next Admin/Staff Reminders scheduled for {NextRun} (Australia/Sydney Time). Delay: {Delay}", nextRunInAus, delay);

                    // Wait until the target time
                    await Task.Delay(delay, stoppingToken);

                    // Trigger the reminders
                    await SendReminders();
                    
                    // Small delay to ensure we don't trigger twice in the same second
                    await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in Admin Reminder Worker cycle.");
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); 
                }
            }
        }

        private async Task SendReminders()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CRM_Api.Models.User>>();
                var adminReminderService = scope.ServiceProvider.GetRequiredService<IAdminReminderService>();

                // Fetch users in Admin and SuperAdmin roles
                var admins = await userManager.GetUsersInRoleAsync("Admin");
                var superAdmins = await userManager.GetUsersInRoleAsync("SuperAdmin");

                // Combine and filter unique emails
                var recipientEmails = admins.Concat(superAdmins)
                    .Select(u => u.Email)
                    .Where(e => !string.IsNullOrEmpty(e))
                    .Distinct()
                    .ToList();

                if (!recipientEmails.Any())
                {
                    _logger.LogWarning("No users found with 'Admin' or 'SuperAdmin' roles. No reminders sent.");
                    return;
                }

                foreach (var email in recipientEmails)
                {
                    _logger.LogInformation("Triggering Scheduled Reminders for {Email}", email);
                    
                    // Send Daily Checklist
                    await adminReminderService.SendDailyAdminReminderAsync(email!);

                    // Send Overdue Job Report (Dynamic Table)
                    await adminReminderService.SendOverdueJobReminderAsync(email!);
                }

                // Trigger Staff Reminders (Personalized)
                var staffReminderService = scope.ServiceProvider.GetRequiredService<IStaffReminderService>();
                await staffReminderService.SendAllStaffOverdueRemindersAsync();

                // Process Expired Temporary Assignments
                var notificationService = scope.ServiceProvider.GetRequiredService<IJobNotificationService>();
                await notificationService.ProcessExpiredTemporaryAssignmentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send scheduled admin reminders.");
            }
        }
    }
}
