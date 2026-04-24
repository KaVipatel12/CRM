using CRM_Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Api.Services.Interfaces
{
    public interface ICallService
    {
        Task<CallLogPagedResponseDto> GetCallsAsync(CallLogFilterDto filter);
        Task<CallLogDto> GetCallByIdAsync(int id);
        Task<CallLogDto> CreateCallAsync(CallLogCreateDto createDto);
        Task<CallLogDto> UpdateCallAsync(int id, CallLogCreateDto createDto);
        Task<bool> UpdateStatusAsync(int id, int statusId);
        Task<bool> CloseCallAsync(int id);
        Task<IEnumerable<CallLogCommentDto>> GetCommentsAsync(int callLogId);
        Task<CallLogCommentDto> AddCommentAsync(int callLogId, string comment);
        Task<bool> UpdateCommentAsync(int commentId, string comment);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<IEnumerable<PurposeDto>> GetPurposesAsync();
    }
}
