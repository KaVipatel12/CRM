using System.Threading.Tasks;

namespace CRM_Api.Services.Interfaces
{
    public interface IAdminReminderService
    {
        /// <summary>
        /// Sends the daily manual checklist to the admin.
        /// </summary>
        Task<bool> SendDailyAdminReminderAsync(string adminEmail);

        /// <summary>
        /// Sends a summary of all overdue jobs to the admin.
        /// </summary>
        Task<bool> SendOverdueJobReminderAsync(string adminEmail);
    }
}
