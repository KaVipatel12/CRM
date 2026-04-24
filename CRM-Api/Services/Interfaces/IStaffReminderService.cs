using System.Threading.Tasks;

namespace CRM_Api.Services.Interfaces
{
    public interface IStaffReminderService
    {
        /// <summary>
        /// Scans the database for all overdue jobs and sends a summary email to each responsible staff member.
        /// </summary>
        Task<int> SendAllStaffOverdueRemindersAsync();
    }
}
