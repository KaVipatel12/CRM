using System;
using System.Collections.Generic;

namespace CRM_Api.DTOs
{
    public class CallLogFilterDto
    {
        public string? SearchString { get; set; }
        public int? ReceiverId { get; set; }
        public int? ForWhomId { get; set; }
        public int? PurposeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsClosed { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class CallLogDto
    {
        public int Id { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public int? ForWhomId { get; set; }
        public string? ForWhomName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int? PurposeId { get; set; }
        public string? PurposeName { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? StatusColor { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool IsClosed { get; set; }
        public bool IsChecked { get; set; }
        public string OtherPurpose { get; set; } = string.Empty;
        public string NatureOfBusiness { get; set; } = string.Empty;
        public string OtherNatureOfBusiness { get; set; } = string.Empty;
        public string HearAboutUs { get; set; } = string.Empty;
        public string OtherHearAboutUs { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
        public int CommentCount { get; set; }
    }

    public class CallLogPagedResponseDto
    {
        public IEnumerable<CallLogDto> Items { get; set; } = new List<CallLogDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class CallLogCreateDto
    {
        public DateTime ReceiveDate { get; set; }
        public int? ReceiverId { get; set; }
        public int? ForWhomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int? PurposeId { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; } = string.Empty;
        public string OtherPurpose { get; set; } = string.Empty;
        public string NatureOfBusiness { get; set; } = string.Empty;
        public string OtherNatureOfBusiness { get; set; } = string.Empty;
        public string HearAboutUs { get; set; } = string.Empty;
        public string OtherHearAboutUs { get; set; } = string.Empty;
    }

    public class CallLogCommentDto
    {
        public int Id { get; set; }
        public int CallLogId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int? CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }

    public class PurposeDto
    {
        public int Id { get; set; }
        public string PurposeName { get; set; } = string.Empty;
    }
}
