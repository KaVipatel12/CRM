using System;
using System.Collections.Generic;

namespace CRM_Api.DTOs
{
    public class DynamicFieldMasterDto
    {
        public int Id { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FieldType { get; set; } = "string";
        public string? FieldAbbreviation { get; set; }
        public string? DefaultValue { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public string? Options { get; set; }
        public string? DisplayTypeIds { get; set; }
    }

    public class CreateDynamicFieldMasterDto
    {
        public string FieldName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string FieldType { get; set; } = "string";
        public string? FieldAbbreviation { get; set; }
        public string? DefaultValue { get; set; }
        public string? Category { get; set; }
        public string? Options { get; set; }
        public string? DisplayTypeIds { get; set; }
    }

    public class DynamicFieldValueDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FieldId { get; set; }
        public string? FieldValue { get; set; }
        public string? FieldDisplayName { get; set; } // For UI convenience
    }

    public class UpsertDynamicFieldValueDto
    {
        public int FieldId { get; set; }
        public string? FieldValue { get; set; }
    }
}
