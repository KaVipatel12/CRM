using System;

namespace CRM_Api.DTOs
{
    public class FileUploadInfoDto
    {
        public int Id { get; set; }
        public int FileType { get; set; }
        public string FileOriginalName { get; set; } = string.Empty;
        public string FileServerPath { get; set; } = string.Empty;
        public long? FileSize { get; set; }
        public long? RecordCount { get; set; }
        public long? RecordProcessed { get; set; }
        public long? RecordFailed { get; set; }
        public int UploadedBy { get; set; }
        public string? UserName { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public int? ProcessResult { get; set; }
        public string? ProcessResultLogFile { get; set; }
    }

    public class FileUploadRequestDto
    {
        public int FileType { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}
