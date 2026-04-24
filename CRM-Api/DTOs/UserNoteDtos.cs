using System;

namespace CRM_Api.DTOs
{
    public class UserNoteDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }

    public class CreateUserNoteDto
    {
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsPinned { get; set; } = false;
        public int DisplayOrder { get; set; } = 0;
    }

    public class UpdateUserNoteDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class UpdateNoteOrderDto
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
    }
}
