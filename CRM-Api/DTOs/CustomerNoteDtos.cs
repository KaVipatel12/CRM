using System;

namespace CRM_Api.DTOs
{
    public class CustomerNoteDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? CreatedUserName { get; set; }
    }

    public class CreateCustomerNoteDto
    {
        public int CustomerId { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
    }

    public class UpdateCustomerNoteDto
    {
        public int Id { get; set; }
        public string NoteText { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
    }
}
