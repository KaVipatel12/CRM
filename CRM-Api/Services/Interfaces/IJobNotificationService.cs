using CRM_Api.Models.Entities.Operations;
using System.Threading.Tasks;

namespace CRM_Api.Services.Interfaces
{
    public interface IJobNotificationService
    {
        /// <summary>
        /// Notifies the responsible person and owner about a new job assignment.
        /// </summary>
        Task NotifyAssignmentAsync(int jobId, int? previousResponsibleId = null);

        /// <summary>
        /// Notifies relevant parties when a job status changes (e.g., to Ready for Check).
        /// </summary>
        Task NotifyStatusChangeAsync(int jobId, int oldStatusId, int newStatusId);
        Task NotifyTemporaryAssignmentAsync(int jobId, int temporaryAssigneeId, DateTime untilDate, string note);
        Task ProcessExpiredTemporaryAssignmentsAsync();
        Task NotifyCommentAsync(int jobId, int commentId);
    }
}
