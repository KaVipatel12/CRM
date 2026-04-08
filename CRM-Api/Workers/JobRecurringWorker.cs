using CRM_Api.Data;
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
    /// 4. If the period end is within the next 7 days, create the next period.
    /// 5. The new period's Deadline is calculated from DueDateDays + DueDateBasis
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
            using PeriodicTimer timer = new(TimeSpan.FromSeconds(30));

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

                // Find all active recurring jobs with a mode set
                var recurringJobs = await dbContext.Jobs
                    .Include(j => j.Tasks)
                    .Where(j => j.IsRecurring
                             && j.RecurringMode != null
                             && j.StartDate.HasValue)
                    .ToListAsync(cancellationToken);

                int createdCount = 0;

                foreach (var job in recurringJobs)
                {
                    // 1. Calculate when this period ends based on StartDate + RecurringMode
                    DateTime periodEnd = CalculatePeriodEnd(job.StartDate!.Value, job.RecurringMode!);

                    // 2. Only process if the period end is within the next 7 days
                    if (periodEnd > now.AddDays(7)) continue;

                    // 3. Check: has TargetEndDate been set? If yes, has it passed?
                    //    TargetEndDate = "Stop Recurring After" date
                    //    NULL means recur forever (like old system: WHERE EndDate IS NULL)
                    DateTime nextPeriodStart = periodEnd.AddDays(1);
                    if (job.TargetEndDate.HasValue && nextPeriodStart > job.TargetEndDate.Value)
                    {
                        // Past the stop date, skip
                        continue;
                    }

                    // 4. Check if the next period already exists (prevent duplicates)
                    bool nextExists = await dbContext.Jobs.AnyAsync(
                        j => j.ParentJobId == job.Id, cancellationToken);
                    if (nextExists) continue;

                    _logger.LogInformation($"Creating next period for Job ID {job.Id}: '{job.Caption}' (Period {job.Period ?? 1})");

                    // 5. Calculate next period's end date
                    DateTime nextPeriodEnd = CalculatePeriodEnd(nextPeriodStart, job.RecurringMode!);

                    // 6. Calculate Deadline using DueDateDays + DueDateBasis
                    //    (matches old system: DueMode='d'→ days, 'w'→ weeks, else→ months)
                    DateTime? nextDeadline = CalculateDeadline(
                        nextPeriodStart, job.DueDateDays, job.DueDateBasis);

                    // 7. Create the next period as a new Job
                    var newJob = new Job
                    {
                        CustomerId = job.CustomerId,
                        JobTypeId = job.JobTypeId,
                        Caption = job.Caption,
                        Description = job.Description,
                        Priority = job.Priority,
                        CurrentStage = 1, // Reset to Active/New
                        StartDate = nextPeriodStart,
                        Deadline = nextDeadline,
                        OwnerId = job.OwnerId,
                        ResponsibleId = job.ResponsibleId,
                        IsActive = true,
                        IsRecurring = true,
                        IsInternal = job.IsInternal,
                        RecurringMode = job.RecurringMode,
                        Period = (job.Period ?? 1) + 1,
                        TargetEndDate = job.TargetEndDate, // Carry forward the stop date
                        DueDateDays = job.DueDateDays,     // Carry forward the due rule
                        DueDateBasis = job.DueDateBasis,   // Carry forward the due rule
                        ParentJobId = job.Id,
                        CreatedDate = DateTime.Now,
                        UpdateDateTime = DateTime.Now
                    };

                    dbContext.Jobs.Add(newJob);
                    await dbContext.SaveChangesAsync(cancellationToken);

                    // 8. Clone Tasks (Checklist) with reset status
                    if (job.Tasks.Any())
                    {
                        var newTasks = job.Tasks.Select(t => new JobTask
                        {
                            JobId = newJob.Id,
                            Description = t.Description,
                            IsCompleted = false,
                            Sequence = t.Sequence,
                            CreatedDate = DateTime.Now
                        }).ToList();

                        dbContext.JobTasks.AddRange(newTasks);
                    }

                    // 9. Log history on both old and new job
                    dbContext.JobHistories.Add(new JobHistory
                    {
                        JobId = job.Id,
                        Event = $"Next period (Period {newJob.Period}) auto-created → Job ID {newJob.Id}",
                        Timestamp = DateTime.Now,
                        UserId = 0 // System
                    });

                    dbContext.JobHistories.Add(new JobHistory
                    {
                        JobId = newJob.Id,
                        Event = $"Auto-created from previous period (Job ID {job.Id}, Period {job.Period ?? 1})",
                        Timestamp = DateTime.Now,
                        UserId = 0 // System
                    });

                    createdCount++;
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

        /// <summary>
        /// Calculate when the current period ends based on the recurring mode.
        /// Matches old system logic (lines 963-977 of TaskService.cs).
        /// </summary>
        private DateTime CalculatePeriodEnd(DateTime periodStart, string mode)
        {
            return mode.ToLower() switch
            {
                "weekly" => periodStart.AddDays(6),
                "fortnightly" => periodStart.AddDays(13),
                "monthly" => periodStart.AddMonths(1).AddDays(-1),
                "quarterly" => periodStart.AddMonths(3).AddDays(-1),
                "yearly" => periodStart.AddYears(1).AddDays(-1),
                _ => periodStart.AddMonths(1).AddDays(-1) // Default monthly
            };
        }

        /// <summary>
        /// Calculate deadline from DueDateDays + DueDateBasis.
        /// Matches old system logic (lines 1500-1515 of TaskService.cs):
        ///   'd' → StartDate + (Duration - 1) days
        ///   'w' → StartDate + (Duration * 7 - 1) days
        ///   'm' → StartDate + Duration months - 1 day
        /// </summary>
        private DateTime? CalculateDeadline(DateTime periodStart, int? dueDays, string? dueBasis)
        {
            if (!dueDays.HasValue || dueDays.Value == 0 || string.IsNullOrEmpty(dueBasis))
                return null;

            return dueBasis.ToLower() switch
            {
                "days" => periodStart.AddDays(dueDays.Value - 1),
                "weeks" => periodStart.AddDays((dueDays.Value * 7) - 1),
                "months" => periodStart.AddMonths(dueDays.Value).AddDays(-1),
                _ => null
            };
        }
    }
}
