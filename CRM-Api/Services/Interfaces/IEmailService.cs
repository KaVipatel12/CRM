using System.Threading.Tasks;

namespace CRM_Api.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, string? title = null, byte[]? attachment = null, string? attachmentFileName = null);

    }
}
