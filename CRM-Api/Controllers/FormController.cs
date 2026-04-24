using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_Api.Data;
using CRM_Api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CRM_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly Services.Interfaces.IEmailService _emailService;

        public FormController(AppDbContext context, IWebHostEnvironment env, Services.Interfaces.IEmailService emailService)
        {
            _context = context;
            _env = env;
            _emailService = emailService;
        }

        // GET: api/Form
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormDto>>> GetForms([FromQuery] int? customerId)
        {
            int? clientType = null;
            if (customerId.HasValue && customerId.Value > 0)
            {
                clientType = await _context.Customers
                    .Where(c => c.Id == customerId.Value)
                    .Select(c => (int?)c.ClientType)
                    .FirstOrDefaultAsync();
            }

            var query = _context.FormMasters.Where(f => f.IsActive);

            var forms = await query
                .OrderBy(f => f.DisplayOrder)
                .Select(f => new FormDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Slug = f.Slug,
                    Category = f.Category,
                    Icon = f.Icon,
                    AllowPdf = f.AllowPdf,
                    AllowEmail = f.AllowEmail,
                    AllowView = f.AllowView,
                    AllowDownload = f.AllowDownload,
                    DisplayOrder = f.DisplayOrder,
                    VisibleForClientTypes = f.VisibleForClientTypes
                })
                .ToListAsync();

            if (clientType.HasValue)
            {
                // Filter based on client type
                forms = forms.Where(f => 
                    string.IsNullOrEmpty(f.VisibleForClientTypes) || 
                    f.VisibleForClientTypes.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Contains(clientType.Value.ToString())
                ).ToList();
            }

            return forms;
        }

        // GET: api/Form/slug/individual-tax-return
        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<FormDto>> GetFormBySlug(string slug)
        {
            var form = await _context.FormMasters
                .Where(f => f.Slug == slug && f.IsActive)
                .Select(f => new FormDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Slug = f.Slug,
                    Category = f.Category,
                    Icon = f.Icon,
                    AllowPdf = f.AllowPdf,
                    AllowEmail = f.AllowEmail,
                    AllowView = f.AllowView,
                    AllowDownload = f.AllowDownload,
                    DisplayOrder = f.DisplayOrder
                })
                .FirstOrDefaultAsync();

            if (form == null)
            {
                return NotFound();
            }

            return form;
        }
        // GET: api/Form/pdf/company-tax-return
        [HttpGet("pdf/{slug}")]
        public async Task<ActionResult<FormPdfResponseDto>> GetFormPdf(string slug, [FromQuery] int customerId, [FromQuery] int month = 0, [FromQuery] int year = 0)
        {
            Models.Entities.Customer.Customer customer = null;
            if (customerId > 0)
            {
                customer = await _context.Customers
                    .Include(c => c.IndividualInfo)
                    .Include(c => c.CompanyInfo)
                    .Include(c => c.ContactInfo)
                    .Include(c => c.Addresses)
                    .Include(c => c.BankAccounts)
                    .FirstOrDefaultAsync(c => c.Id == customerId);
                
                if (customer == null) return NotFound("Customer not found");
            }

            string fileName = GetTemplatePathBySlug(slug);
            if (string.IsNullOrEmpty(fileName)) return BadRequest("Form template not mapped");

            // Handle static files in Docs folder
            if (fileName.StartsWith("Docs/"))
            {
                string filePath = Path.Combine(_env.ContentRootPath, "Forms", fileName);
                if (!System.IO.File.Exists(filePath)) return NotFound($"Document file {fileName} not found");

                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return Ok(new FormPdfResponseDto
                {
                    Base64PDF = Convert.ToBase64String(fileBytes),
                    FileName = Path.GetFileName(filePath)
                });
            }

            string templatePath = Path.Combine(_env.ContentRootPath, "Forms", fileName);
            if (!System.IO.File.Exists(templatePath)) return NotFound($"Template file {fileName} not found");

            string htmlContent = await System.IO.File.ReadAllTextAsync(templatePath);
            
            // Perform replacements
            htmlContent = ReplaceCustomerPlaceholders(htmlContent, customer);
            htmlContent = ReplaceDatePlaceholders(htmlContent, month, year);

            try
            {
                var pdfHelper = new Helpers.HtmlToPdfHelper();
                string base64Pdf = await pdfHelper.GenerateHTMLToPDFAsync(htmlContent, _env.ContentRootPath);

                return Ok(new FormPdfResponseDto
                {
                    Base64PDF = base64Pdf,
                    FileName = $"{slug}_{customerId}_{DateTime.Now:yyyyMMdd}.pdf"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"PDF Generation failed: {ex.Message}");
            }
        }

        [HttpPost("email/{slug}")]
        public async Task<IActionResult> SendEmailForm(string slug, [FromQuery] int customerId, [FromBody] EmailDto emailDetails)
        {
            Models.Entities.Customer.Customer customer = null;
            if (customerId > 0)
            {
                customer = await _context.Customers
                    .Include(c => c.IndividualInfo)
                    .Include(c => c.CompanyInfo)
                    .Include(c => c.ContactInfo)
                    .Include(c => c.Addresses)
                    .Include(c => c.BankAccounts)
                    .FirstOrDefaultAsync(c => c.Id == customerId);

                if (customer == null) return NotFound("Customer not found");
            }

            string fileName = GetTemplatePathBySlug(slug);
            if (string.IsNullOrEmpty(fileName)) return BadRequest("Form template not mapped");

            string base64Doc = "";
            string finalFileName = "";

            if (fileName.StartsWith("Docs/"))
            {
                string filePath = Path.Combine(_env.ContentRootPath, "Forms", fileName);
                if (!System.IO.File.Exists(filePath)) return NotFound($"Document file {fileName} not found");

                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                base64Doc = Convert.ToBase64String(fileBytes);
                finalFileName = Path.GetFileName(filePath);
            }
            else
            {
                string templatePath = Path.Combine(_env.ContentRootPath, "Forms", fileName);
                if (!System.IO.File.Exists(templatePath)) return NotFound($"Template file {fileName} not found");

                string htmlContent = await System.IO.File.ReadAllTextAsync(templatePath);
                htmlContent = ReplaceCustomerPlaceholders(htmlContent, customer);
                htmlContent = ReplaceDatePlaceholders(htmlContent);

                var pdfHelper = new Helpers.HtmlToPdfHelper();
                base64Doc = await pdfHelper.GenerateHTMLToPDFAsync(htmlContent, _env.ContentRootPath);
                finalFileName = $"{slug}_{customerId}_{DateTime.Now:yyyyMMdd}.pdf";
            }

            try
            {
                byte[] fileBytes = Convert.FromBase64String(base64Doc);
                string subject = !string.IsNullOrEmpty(emailDetails.Subject) ? emailDetails.Subject : $"Form Delivery: {slug}";
                string body = !string.IsNullOrEmpty(emailDetails.Body) ? emailDetails.Body : $"Please find the requested form attached.";

                await _emailService.SendEmailAsync(
                    emailDetails.EmailId,
                    subject,
                    body,
                    "Form Delivery",
                    fileBytes,
                    finalFileName
                );

                return Ok(new { Message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Email sending failed: {ex.Message}");
            }
        }

        private string GetTemplatePathBySlug(string slug)
        {
            return slug switch
            {
                "individual-tax-return" => "IndividualTaxReturn.html",
                "bas-bookkeeping-checklist" => "BASBookkeepingChecklist.html",
                "bas-lodgment-checklist" => "BASChecklist.html",
                "tax-return-partnership" => "PartnershipTaxReturnForm.html",
                "tax-return-company" => "CompanyTaxReturnForm.html",
                "business-registration" => "BusinessRegistrationForm.html",
                "bookkeeping-set" => "Docs/BookkeepingSet.pdf",
                "employee-details" => "StaffDetailsForm.html",
                "inquiry-form" => "InquiryForm.html",
                "client-enrollment" => "ClientEnrollmentForm.html",
                "rental-property" => "RentalPropertyForm.html",
                "update-client-details" => "UpdateClientDetailForm.html",
                "superannuation-claim" => "SuperAnnuationClaimFrom.html",
                "investment-client-form" => "Docs/SSP-Investment-Client-Form.pdf",
                "employee-details-staff" => "Docs/Employee-Details-Form-For-SSPStaff.pdf",
                "call-tracker" => "CallTracker.html",
                "home-loan-application" => "Docs/HomeLoanApplicationForm.pdf",
                "authority-dasp" => "Docs/AuthorityFormDASP.docx",
                "letterhead" => "Docs/Letterhead.docx",
                "letterhead-sukhwinder" => "Docs/SukhwinderLetterhead.docx",
                "letterhead-napa" => "Docs/Don't-Tell-Tiger-NapaArinaphat.docx",
                "letterhead-tiger-napa" => "Docs/Don't-Tell-Tiger-NapaArinaphat.docx",
                "letterhead-tiger-sukhwinder" => "Docs/Don't-Tell-Tiger-Sukhwinder.docx",
                _ => string.Empty
            };
        }

        private string ReplaceCustomerPlaceholders(string html, Models.Entities.Customer.Customer customer)
        {
            if (customer == null)
            {
                // Blank replacements for all tags
                var tags = new[] { "@Name@", "@Name1@", "@ContactName@", "@Email@", "@Phone@", "@CellPhone@", "@HomePhone@", "@WorkPhone@", "@ABN@", "@ABNNumber@", "@TFN@", "@TFNNumber@", "@FirstName@", "@LastName@", "@Title@", "@Salutation@", "@DateOfBirth@", "@DOB@", "@FullPhysicalAddress@", "@FullPostalAddress@", "@AddressLine1@", "@City@", "@State@", "@Postcode@", "@PostalCode@", "@AccountName@", "@BankName@", "@BSB@", "@AccountNumber@" };
                foreach (var tag in tags) html = html.Replace(tag, "");
                return html;
            }

            // Basic Info
            html = html.Replace("@Name@", customer.Name)
                       .Replace("@Name1@", customer.Name)
                       .Replace("@ContactName@", customer.ContactInfo?.ContactName ?? customer.Name)
                       .Replace("@Email@", customer.ContactInfo?.Email ?? "")
                       .Replace("@Phone@", customer.ContactInfo?.CellPhone ?? "")
                       .Replace("@CellPhone@", customer.ContactInfo?.CellPhone ?? "")
                       .Replace("@HomePhone@", customer.ContactInfo?.HomePhone ?? "")
                       .Replace("@WorkPhone@", customer.ContactInfo?.WorkPhone ?? "")
                       .Replace("@ABN@", customer.ABNNumber ?? "")
                       .Replace("@ABNNumber@", customer.ABNNumber ?? "")
                       .Replace("@TFN@", customer.TFNNumber ?? "")
                       .Replace("@TFNNumber@", customer.TFNNumber ?? "");

            // Individual Info
            if (customer.IndividualInfo != null)
            {
                html = html.Replace("@FirstName@", customer.IndividualInfo.FirstName ?? "")
                           .Replace("@LastName@", customer.IndividualInfo.LastName ?? "")
                           .Replace("@Title@", customer.IndividualInfo.Title ?? "")
                           .Replace("@Salutation@", customer.ContactInfo?.Salutation ?? customer.IndividualInfo.Title ?? "")
                           .Replace("@DateOfBirth@", customer.IndividualInfo.DateOfBirth?.ToString("dd/MM/yyyy") ?? "")
                           .Replace("@DOB@", customer.IndividualInfo.DateOfBirth?.ToString("dd/MM/yyyy") ?? "");
            }

            // Address Info
            var physicalAddress = customer.Addresses?.FirstOrDefault(a => a.Type == 2) ?? customer.Addresses?.FirstOrDefault();
            if (physicalAddress != null)
            {
                string fullAddress = $"{physicalAddress.AddressLine1}, {physicalAddress.City} {physicalAddress.State} {physicalAddress.PostalCode}";
                html = html.Replace("@FullPhysicalAddress@", fullAddress)
                           .Replace("@FullPostalAddress@", fullAddress)
                           .Replace("@AddressLine1@", physicalAddress.AddressLine1 ?? "")
                           .Replace("@City@", physicalAddress.City ?? "")
                           .Replace("@State@", physicalAddress.State ?? "")
                           .Replace("@Postcode@", physicalAddress.PostalCode ?? "")
                           .Replace("@PostalCode@", physicalAddress.PostalCode ?? "");
            }

            // Bank Account Info
            var bankAccount = customer.BankAccounts?.FirstOrDefault();
            if (bankAccount != null)
            {
                html = html.Replace("@AccountName@", bankAccount.AccountName ?? "")
                           .Replace("@BankName@", bankAccount.BankName ?? "")
                           .Replace("@BSB@", bankAccount.BSB ?? "")
                           .Replace("@AccountNumber@", bankAccount.AccountNumber ?? "");
            }
            else
            {
                html = html.Replace("@AccountName@", "").Replace("@BankName@", "").Replace("@BSB@", "").Replace("@AccountNumber@", "");
            }

            return html;
        }

        private string ReplaceDatePlaceholders(string html, int month = 0, int year = 0)
        {
            var now = DateTime.Now;
            html = html.Replace("@DD@", now.ToString("dd"))
                       .Replace("@MM@", now.ToString("MM"))
                       .Replace("@YYYY@", now.ToString("yyyy"))
                       .Replace("@Date@", now.ToString("dd/MM/yyyy"));

            if (month > 0 && year > 0)
            {
                var targetDate = new DateTime(year, month, 1);
                html = html.Replace("@Month@", targetDate.ToString("MMMM"))
                           .Replace("@Year@", year.ToString());
            }
            else
            {
                html = html.Replace("@Month@", now.ToString("MMMM"))
                           .Replace("@Year@", now.ToString("yyyy"));
            }

            return html;
        }
    }
}
