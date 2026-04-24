namespace CRM_Api.DTOs
{
    public class FormDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Icon { get; set; }
        public bool AllowPdf { get; set; }
        public bool AllowEmail { get; set; }
        public bool AllowView { get; set; }
        public bool AllowDownload { get; set; }
        public int DisplayOrder { get; set; }
        public string? VisibleForClientTypes { get; set; }
    }

    public class FormPdfResponseDto
    {
        public string Base64PDF { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
    public class EmailDto
    {
        public string EmailId { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
