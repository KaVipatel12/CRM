using CRM_Api.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpConfigurationService _smtpConfigService;
        private readonly ILogger<EmailService> _logger;

        private readonly IWebHostEnvironment _env;

        public EmailService(ISmtpConfigurationService smtpConfigService, ILogger<EmailService> logger, IWebHostEnvironment env)
        {
            _smtpConfigService = smtpConfigService;
            _logger = logger;
            _env = env;
        }

        public async Task SendEmailAsync(string to, string subject, string body, string? title = null, byte[]? attachment = null, string? attachmentFileName = null)
        {
            // 1. Get configuration from the Database
            var dbConfig = await _smtpConfigService.GetActiveConfigurationAsync();
            
            if (dbConfig == null)
            {
                _logger.LogError("Failed to send email: No active SMTP configuration found.");
                throw new InvalidOperationException("No active SMTP configuration found in the database. Please configure email settings in the Admin panel.");
            }

            string host = dbConfig.Host;
            int port = dbConfig.Port;
            string username = dbConfig.Username;
            string password = dbConfig.EncryptedPassword; 
            string fromEmail = dbConfig.FromEmail;
            string fromName = dbConfig.FromName;

            _logger.LogInformation("Attempting to send email to {To} via {Host}", to, host);

            List<string> ccEmails = new List<string>();
            if (!string.IsNullOrEmpty(dbConfig.CCEmailsJson))
            {
                try {
                    ccEmails = System.Text.Json.JsonSerializer.Deserialize<List<string>>(dbConfig.CCEmailsJson) ?? new List<string>();
                } catch { /* Ignore malformed JSON */ }
            }
            
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromName, fromEmail));
            email.To.Add(MailboxAddress.Parse(to));
            
            // Add CCs in a loop
            foreach (var cc in ccEmails)
            {
                if (!string.IsNullOrWhiteSpace(cc))
                {
                    email.Cc.Add(MailboxAddress.Parse(cc.Trim()));
                }
            }

            email.Subject = subject;

            // 2. Load Master Template and replace placeholders
            string templatePath = Path.Combine(_env.ContentRootPath, "Templates", "MasterEmailTemplate.html");
            string styledHtmlBody;

            if (File.Exists(templatePath))
            {
                string masterTemplate = await File.ReadAllTextAsync(templatePath);
                styledHtmlBody = masterTemplate
                    .Replace("{{Title}}", title ?? subject)
                    .Replace("{{Content}}", body)
                    .Replace("{{Year}}", DateTime.Now.Year.ToString());
            }
            else
            {
                // Fallback if file is missing
                styledHtmlBody = body;
                _logger.LogWarning("Master Email Template not found at {Path}. Sending raw body.", templatePath);
            }

            var builder = new BodyBuilder();
            builder.HtmlBody = styledHtmlBody;

            if (attachment != null && attachment.Length > 0)
            {
                builder.Attachments.Add(attachmentFileName ?? "document.pdf", attachment);
            }

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            
            // Connect to the SMTP server using the fetched settings
            await smtp.ConnectAsync(host, port, SecureSocketOptions.StartTls);
            
            // Authenticate using the fetched credentials
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                await smtp.AuthenticateAsync(username, password);
            }

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
