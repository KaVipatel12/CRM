using CRM_Api.Data;
using CRM_Api.Models.Entities.Operations;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Workers
{
    public class TemporaryAssignmentRevertWorker : BackgroundService
    {
        private readonly ILogger<TemporaryAssignmentRevertWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TemporaryAssignmentRevertWorker(
            ILogger<TemporaryAssignmentRevertWorker> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Temporary Assignment Revert Worker running.");

            // Poll every 30 minutes
            using PeriodicTimer timer = new(TimeSpan.FromMinutes(30));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await CheckAndRevertExpiredAssignments(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Temporary Assignment Revert Worker is stopping.");
            }
        }

        private async Task CheckAndRevertExpiredAssignments(CancellationToken cancellationToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var now = DateTime.Now;

                // Find jobs where the temporary assignment has expired
                var expiredJobs = await dbContext.Jobs
                    .Where(j => j.TemporaryAssignmentUntil.HasValue 
                             && j.TemporaryAssignmentUntil.Value < now 
                             && j.OriginalResponsibleId != null)
                    .ToListAsync(cancellationToken);

                if (expiredJobs.Any())
                {
                    _logger.LogInformation($"Found {expiredJobs.Count} expired temporary assignments. Reverting...");

                    foreach (var job in expiredJobs)
                    {
                        var oldTempUserId = job.ResponsibleId;
                        
                        // Revert to original
                        job.ResponsibleId = job.OriginalResponsibleId;
                        
                        // Clear tracking fields
                        job.OriginalResponsibleId = null;
                        job.TemporaryAssignmentUntil = null;
                        job.TemporaryAssignmentNote = null;
                        job.UpdateDateTime = DateTime.Now;

                        // Log history
                        dbContext.JobHistories.Add(new JobHistory
                        {
                            JobId = job.Id,
                            Event = $"Temporary assignment expired. Reverted from Staff ID {oldTempUserId} to original Staff ID {job.ResponsibleId}.",
                            Timestamp = DateTime.Now,
                            UserId = 0 // System
                        });
                    }

                    await dbContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation("Expired temporary assignments successfully reverted.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while reverting expired temporary assignments.");
            }
        }
    }
}
