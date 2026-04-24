using System.Collections.Generic;

namespace CRM_Api.DTOs
{
    public class ReportFieldDto
    {
        public string Key { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Category { get; set; } = "General"; // General, Address, Bank, Dynamic, etc.
        public bool IsDynamic { get; set; }
        public int? DynamicFieldId { get; set; }
    }

    public class ClientDetailsReportFilter
    {
        public int? ContactType { get; set; }
        public string? Partner { get; set; }
        public int? PartnerId { get; set; }
        public string? Manager { get; set; }
        public int? ClientType { get; set; }
        public string? Group { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsExcluded { get; set; }
        public int? StaffInCharge { get; set; }
        public List<int>? SelectedCustomerIds { get; set; }
        public int? TradingStatus { get; set; }
        public string? OrderBy { get; set; } = "Name";
        public string? OrderDirection { get; set; } = "ASC";
        public List<string> SelectedFieldKeys { get; set; } = new List<string>();
        public string ExportFormat { get; set; } = "csv"; // csv, txt
    }

    public class FSNotesReportFilter
    {
        public int? ContactType { get; set; }
        public string? Partner { get; set; }
        public int? PartnerId { get; set; }
        public int? StaffInCharge { get; set; }
        public int? ClientType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsExcluded { get; set; }
        public List<int> SelectedNoteTypeIds { get; set; } = new List<int>();
        public List<int>? SelectedCustomerIds { get; set; }
        public string? OrderBy { get; set; } = "Name";
        public string? OrderDirection { get; set; } = "ASC";
        public string ExportFormat { get; set; } = "csv"; // csv, txt
    }
}
