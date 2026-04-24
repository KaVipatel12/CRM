using System;

namespace CRM_Api.DTOs
{
    public class FSNoteDto
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public int FSNoteMasterId { get; set; }
        public string NoteType { get; set; } = string.Empty;
        public string NoteContent { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string? CreatedByUserName { get; set; }
        public string? UpdatedByUserName { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }

    public class CreateFSNoteDto
    {
        public int CustomerId { get; set; }
        public int FSNoteMasterId { get; set; }
        public string NoteContent { get; set; } = string.Empty;
    }
}
