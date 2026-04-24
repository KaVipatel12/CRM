using CRM_Api.Data;
using CRM_Api.Helpers;
using CRM_Api.Models.Entities.Operations;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Workers
{
    /// <summary>
    /// Background worker that auto-creates the next period for recurring jobs.
    /// 
    /// Logic (matching legacy system):
    /// 1. Find all recurring jobs where RecurringMode is set.
    /// 2. If TargetEndDate is NULL → job recurs forever.
    ///    If TargetEndDate has a value → job stops recurring after that date.
    /// 3. Calculate the current period's end based on StartDate + RecurringMode.
    /// 4. The new period's Deadline is calculated from DueDateDays + DueDateBasis
    ///    (matching the old system's DueMode + DueDuration logic).
    /// </summary>
    public class JobRecurringWorker : BackgroundService
    {
        private readonly ILogger<JobRecurringWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public JobRecurringWorker(
            ILogger<JobRecurringWorker> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Job Recurring Auto-Creation Worker running.");

            // Poll every 30 seconds for TESTING (change to 24 hours in production)
            using PeriodicTimer timer = new(TimeSpan.FromHours(24));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await ProcessRecurringJobs(stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Job Recurring Worker is stopping.");
            }
        }

        private async Task ProcessRecurringJobs(CancellationToken cancellationToken)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var now = DateTime.Now;

                // Optimized Filter: Only pull jobs that are actually due for auto-creation TODAY and are still ACTIVE
                // CRITICAL: We also join with Customer to ensure we don't create jobs for archived/inactive clients.
                var recurringJobs = await dbContext.Jobs
                    .Include(j => j.Tasks)
                    .Include(j => j.Customer)
                    .Where(j => j.IsActive
                             && j.IsRecurring 
                             && j.RecurringMode != null 
                             && j.NextAutoCreateDate != null 
                             && j.NextAutoCreateDate <= now
                             && j.Customer != null
                             && j.Customer.IsActive != false
                             && j.Customer.IsArchived != true
                             && j.Customer.IsDeleted == false)
                    .ToListAsync(cancellationToken);

                int createdCount = 0;

                foreach (var triggerJob in recurringJobs)
                {
                    var currentSourceJob = triggerJob;
                    var baseJob = triggerJob; 

                    while (true)
                    {
                        // 1. Calculate when the CURRENT period ends
                        DateTime periodEnd = JobScheduleHelper.CalculatePeriodEnd(currentSourceJob.StartDate!.Value, currentSourceJob.RecurringMode!);

                        // 2. Only process if the period end is within the next 2 days (or in the past)
                        if (periodEnd > now.AddDays(2)) break;

                        // 3. Check for TargetEndDate
                        DateTime nextPeriodStart = periodEnd.AddDays(1);
                        if (baseJob.TargetEndDate.HasValue && nextPeriodStart > baseJob.TargetEndDate.Value) break;

                        // 4. Check if the next period already exists in the chain
                        var nextInChain = await dbContext.Jobs
                            .FirstOrDefaultAsync(j => j.ParentJobId == currentSourceJob.Id, cancellationToken);

                        if (nextInChain != null)
                        {
                            currentSourceJob = nextInChain;
                            continue;
                        }

                        _logger.LogInformation($"Creating next period for Job ID {currentSourceJob.Id}: '{baseJob.Caption}'");

                        DateTime nextPeriodEnd = JobScheduleHelper.CalculatePeriodEnd(nextPeriodStart, baseJob.RecurringMode!);
                        DateTime? nextDeadline = JobScheduleHelper.CalculateDeadline(nextPeriodStart, baseJob.DueDateDays, baseJob.DueDateBasis);

                        var newJob = new Job
                        {
                            CustomerId = baseJob.CustomerId,
                            JobTypeId = baseJob.JobTypeId,
                            Caption = baseJob.Caption,
                            Description = baseJob.Description,
                            Priority = baseJob.Priority,
                            CurrentStage = 1, // Not Yet In
                            StartDate = nextPeriodStart,
                            Deadline = nextDeadline,
                            OwnerId = baseJob.OwnerId,
                            ResponsibleId = baseJob.OriginalResponsibleId ?? baseJob.ResponsibleId,
                            IsActive = true,
                            IsRecurring = true,
                            RecurringMode = baseJob.RecurringMode,
                            Period = (currentSourceJob.Period ?? 1) + 1,
                            ParentJobId = currentSourceJob.Id,
                            DueDateDays = baseJob.DueDateDays,
                            DueDateBasis = baseJob.DueDateBasis,
                            NextAutoCreateDate = JobScheduleHelper.CalculateNextCreationDate(nextPeriodStart, baseJob.RecurringMode!)
                        };

                        dbContext.Jobs.Add(newJob);
                        await dbContext.SaveChangesAsync(cancellationToken);

                        dbContext.JobHistories.Add(new JobHistory
                        {
                            JobId = newJob.Id,
                            Event = $"Auto-created from previous period (Job ID {currentSourceJob.Id}, Period {currentSourceJob.Period ?? 1})"
                        });

                        // Add warning if the previous period is still pending
                        if (currentSourceJob.CurrentStage != 6) // 6 = Completed
                        {
                            dbContext.JobHistories.Add(new JobHistory
                            {
                                JobId = newJob.Id,
                                Event = $"⚠️ WARNING: The previous period (Job ID {currentSourceJob.Id}) is still pending and has not been marked as 'Completed'!",
                                Timestamp = DateTime.Now,
                                UserId = 0 // System
                            });
                        }

                        // IMPORTANT: Clear the trigger date from the PREVIOUS job
                        // (triggerJob is the master, but currentSourceJob is the link we just processed)
                        currentSourceJob.NextAutoCreateDate = null;
                        
                        createdCount++;
                        // MOVE THE POINTER to the newly created job for the next cycle
                        currentSourceJob = newJob;
                        
                        await dbContext.SaveChangesAsync(cancellationToken);
                        
                        if (createdCount > 50) break; 
                    }
                }

                if (createdCount > 0)
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation($"Successfully created {createdCount} new recurring job periods.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during recurring job auto-creation.");
            }
        }
    }
}
