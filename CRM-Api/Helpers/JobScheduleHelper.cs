using System;

namespace CRM_Api.Helpers
{
    public static class JobScheduleHelper
    {
        /// <summary>
        /// Calculate when the current period ends based on the recurring mode.
        /// </summary>
        public static DateTime CalculatePeriodEnd(DateTime periodStart, string mode)
        {
            if (string.IsNullOrEmpty(mode)) return periodStart.AddMonths(1).AddDays(-1);

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
        /// </summary>
        public static DateTime? CalculateDeadline(DateTime periodStart, int? dueDays, string? dueBasis)
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

        /// <summary>
        /// Determine when the NEXT period should be auto-created.
        /// Default is 2 days before the current period ends.
        /// </summary>
        public static DateTime CalculateNextCreationDate(DateTime periodStart, string mode)
        {
            DateTime periodEnd = CalculatePeriodEnd(periodStart, mode);

            // Buffer: Create 7 days before the end of the current period,
            // matching the exact legacy backend logic.
            return periodEnd.AddDays(-7);
        }
    }
}
