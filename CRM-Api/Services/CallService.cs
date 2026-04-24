using CRM_Api.Data;
using CRM_Api.DTOs;
using CRM_Api.Models.Entities.Operations;
using CRM_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Api.Services
{
    public class CallService : ICallService
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;
        private readonly IEmailService _emailService;

        public CallService(AppDbContext context, IUserContext userContext, IEmailService emailService)
        {
            _context = context;
            _userContext = userContext;
            _emailService = emailService;
        }

        public async Task<CallLogPagedResponseDto> GetCallsAsync(CallLogFilterDto filter)
        {
            var query = _context.CallLogs
                .Include(c => c.PurposeNavigation)
                .Include(c => c.StatusNavigation)
                .Include(c => c.Comments)
                .AsQueryable();

            // Security removed as per request: Anyone can see anyone's calls

            if (!string.IsNullOrWhiteSpace(filter.SearchString))
            {
                var search = filter.SearchString.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(search) || 
                                         c.CompanyName.ToLower().Contains(search) || 
                                         c.Email.ToLower().Contains(search) || 
                                         c.MobileNo.ToLower().Contains(search) ||
                                         c.Remark.ToLower().Contains(search));
            }

            if (filter.ReceiverId.HasValue) query = query.Where(c => c.Receiver == filter.ReceiverId);
            if (filter.ForWhomId.HasValue) query = query.Where(c => c.ForWhom == filter.ForWhomId);
            if (filter.PurposeId.HasValue) query = query.Where(c => c.Purpose == filter.PurposeId);
            if (filter.StatusId.HasValue) query = query.Where(c => c.Status == filter.StatusId);
            if (filter.IsClosed.HasValue) query = query.Where(c => c.IsClosed == filter.IsClosed);
            
            if (filter.FromDate.HasValue) query = query.Where(c => c.ReceiveDate >= filter.FromDate.Value.Date);
            if (filter.ToDate.HasValue) query = query.Where(c => c.ReceiveDate <= filter.ToDate.Value.Date.AddDays(1).AddTicks(-1));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.ReceiveDate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(c => new CallLogDto
                {
                    Id = c.Id,
                    ReceiveDate = c.ReceiveDate,
                    ReceiverId = c.Receiver,
                    ReceiverName = _context.Users.Where(u => u.Id == c.Receiver).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    ForWhomId = c.ForWhom,
                    ForWhomName = _context.Users.Where(u => u.Id == c.ForWhom).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    Name = c.Name,
                    Email = c.Email,
                    MobileNo = c.MobileNo,
                    CompanyName = c.CompanyName,
                    PurposeId = c.Purpose,
                    PurposeName = c.PurposeNavigation != null ? c.PurposeNavigation.PurposeName : "Other",
                    StatusId = c.Status,
                    StatusName = (c.StatusNavigation != null && !string.IsNullOrEmpty(c.StatusNavigation.StatusName)) ? c.StatusNavigation.StatusName : "Pending",
                    StatusColor = (c.StatusNavigation != null && !string.IsNullOrEmpty(c.StatusNavigation.Color)) ? c.StatusNavigation.Color : "gray",
                    Remark = c.Remark,
                    IsClosed = c.IsClosed ?? false,
                    IsChecked = c.IsChecked ?? false,
                    OtherPurpose = c.OtherPurpose,
                    NatureOfBusiness = c.NatureOfBusiness,
                    OtherNatureOfBusiness = c.OtherNatureOfBusiness,
                    HearAboutUs = c.HearAboutUs,
                    OtherHearAboutUs = c.OtherHearAboutUs,
                    UpdateDateTime = c.UpdateDateTime,
                    CommentCount = c.Comments.Count
                })
                .ToListAsync();

            return new CallLogPagedResponseDto
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task<CallLogDto> GetCallByIdAsync(int id)
        {
            return await _context.CallLogs
                .Include(c => c.PurposeNavigation)
                .Include(c => c.StatusNavigation)
                .Where(c => c.Id == id)
                .Select(c => new CallLogDto
                {
                    Id = c.Id,
                    ReceiveDate = c.ReceiveDate,
                    ReceiverId = c.Receiver,
                    ReceiverName = _context.Users.Where(u => u.Id == c.Receiver).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    ForWhomId = c.ForWhom,
                    ForWhomName = _context.Users.Where(u => u.Id == c.ForWhom).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    Name = c.Name,
                    Email = c.Email,
                    MobileNo = c.MobileNo,
                    CompanyName = c.CompanyName,
                    PurposeId = c.Purpose,
                    PurposeName = c.PurposeNavigation != null ? c.PurposeNavigation.PurposeName : "Other",
                    StatusId = c.Status,
                    StatusName = (c.StatusNavigation != null && !string.IsNullOrEmpty(c.StatusNavigation.StatusName)) ? c.StatusNavigation.StatusName : "Pending",
                    StatusColor = (c.StatusNavigation != null && !string.IsNullOrEmpty(c.StatusNavigation.Color)) ? c.StatusNavigation.Color : "gray",
                    Remark = c.Remark,
                    IsClosed = c.IsClosed ?? false,
                    IsChecked = c.IsChecked ?? false,
                    OtherPurpose = c.OtherPurpose,
                    NatureOfBusiness = c.NatureOfBusiness,
                    OtherNatureOfBusiness = c.OtherNatureOfBusiness,
                    HearAboutUs = c.HearAboutUs,
                    OtherHearAboutUs = c.OtherHearAboutUs,
                    UpdateDateTime = c.UpdateDateTime,
                    CommentCount = c.Comments.Count
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CallLogDto> CreateCallAsync(CallLogCreateDto createDto)
        {
            var callLog = new CallLogs
            {
                ReceiveDate = createDto.ReceiveDate,
                Receiver = createDto.ReceiverId,
                ForWhom = createDto.ForWhomId,
                Name = createDto.Name,
                Email = createDto.Email,
                MobileNo = createDto.MobileNo,
                CompanyName = createDto.CompanyName,
                Purpose = createDto.PurposeId,
                Status = createDto.StatusId,
                Remark = createDto.Remark,
                OtherPurpose = createDto.OtherPurpose,
                NatureOfBusiness = createDto.NatureOfBusiness,
                OtherNatureOfBusiness = createDto.OtherNatureOfBusiness,
                HearAboutUs = createDto.HearAboutUs,
                OtherHearAboutUs = createDto.OtherHearAboutUs,
                IsClosed = false,
                IsChecked = false,
                CreatedUserId = _userContext.UserId,
                UpdateUserId = _userContext.UserId,
                UpdateDateTime = DateTime.Now
            };

            _context.CallLogs.Add(callLog);
            await _context.SaveChangesAsync();

            // Send notification to the "For Whom" staff member
            if (callLog.ForWhom.HasValue)
            {
                await SendCallNotificationEmailAsync(callLog.ForWhom.Value, callLog);
            }

            return await GetCallByIdAsync(callLog.Id);
        }

        public async Task<CallLogDto> UpdateCallAsync(int id, CallLogCreateDto createDto)
        {
            var callLog = await _context.CallLogs.FindAsync(id);
            if (callLog == null) return null;

            var oldForWhom = callLog.ForWhom;

            callLog.ReceiveDate = createDto.ReceiveDate;
            callLog.Receiver = createDto.ReceiverId;
            callLog.ForWhom = createDto.ForWhomId;
            callLog.Name = createDto.Name;
            callLog.Email = createDto.Email;
            callLog.MobileNo = createDto.MobileNo;
            callLog.CompanyName = createDto.CompanyName;
            callLog.Purpose = createDto.PurposeId;
            callLog.Status = createDto.StatusId;
            callLog.Remark = createDto.Remark;
            callLog.OtherPurpose = createDto.OtherPurpose;
            callLog.NatureOfBusiness = createDto.NatureOfBusiness;
            callLog.OtherNatureOfBusiness = createDto.OtherNatureOfBusiness;
            callLog.HearAboutUs = createDto.HearAboutUs;
            callLog.OtherHearAboutUs = createDto.OtherHearAboutUs;
            
            callLog.UpdateUserId = _userContext.UserId;
            callLog.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            // Send notification if ForWhom changed or was newly set
            if (callLog.ForWhom.HasValue && callLog.ForWhom != oldForWhom)
            {
                await SendCallNotificationEmailAsync(callLog.ForWhom.Value, callLog);
            }

            return await GetCallByIdAsync(callLog.Id);
        }

        private async Task SendCallNotificationEmailAsync(int userId, CallLogs callLog)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null || string.IsNullOrEmpty(user.Email)) return;

            var receiverName = await _context.Users
                .Where(u => u.Id == callLog.Receiver)
                .Select(u => u.FirstName + " " + u.LastName)
                .FirstOrDefaultAsync() ?? "Unknown";

            var purposeName = await _context.Purposes
                .Where(p => p.ID == callLog.Purpose)
                .Select(p => p.PurposeName)
                .FirstOrDefaultAsync() ?? "Other";

            string subject = $"[Call Alert] New Call Logged for You: {callLog.Name}";
            string body = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
                    <h2 style='color: #2196F3; margin-top: 0;'>New Call Log Assigned</h2>
                    <p>Hello <strong>{user.FirstName}</strong>,</p>
                    <p>A new call has been logged and assigned to you in the CRM.</p>
                    
                    <div style='background-color: #f5f5f5; padding: 15px; border-radius: 4px; margin: 20px 0;'>
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Caller Name:</strong></td><td>{callLog.Name}</td></tr>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Company:</strong></td><td>{callLog.CompanyName ?? "N/A"}</td></tr>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Contact:</strong></td><td>{callLog.MobileNo}</td></tr>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Purpose:</strong></td><td>{purposeName}</td></tr>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Taken By:</strong></td><td>{receiverName}</td></tr>
                            <tr><td style='padding: 5px 0; color: #666;'><strong>Date:</strong></td><td>{callLog.ReceiveDate:dd MMM yyyy HH:mm}</td></tr>
                        </table>
                    </div>

                    <p><strong>Remarks:</strong><br/>{callLog.Remark ?? "No remarks provided."}</p>

                    <div style='text-align: center; margin-top: 30px;'>
                        <a href='http://localhost:4200/calls' style='background-color: #2196F3; color: white; padding: 12px 24px; text-decoration: none; border-radius: 4px; font-weight: bold;'>View in CRM</a>
                    </div>
                    
                    <p style='font-size: 12px; color: #999; margin-top: 40px; border-top: 1px solid #eee; padding-top: 10px;'>
                        This is an automated notification from SSP CRM. Please do not reply to this email.
                    </p>
                </div>";

            try
            {
                await _emailService.SendEmailAsync(user.Email, subject, body, "Call Tracker Notification");
            }
            catch
            {
                // Log error or ignore if email fails to prevent breaking the main flow
            }
        }

        public async Task<bool> UpdateStatusAsync(int id, int statusId)
        {
            var call = await _context.CallLogs.FindAsync(id);
            if (call == null) return false;

            call.Status = statusId;
            call.UpdateUserId = _userContext.UserId;
            call.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CloseCallAsync(int id)
        {
            var call = await _context.CallLogs.FindAsync(id);
            if (call == null) return false;

            call.IsClosed = true;
            call.UpdateUserId = _userContext.UserId;
            call.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CallLogCommentDto>> GetCommentsAsync(int callLogId)
        {
            return await _context.CallLogComments
                .Where(c => c.CallLogId == callLogId)
                .OrderByDescending(c => c.UpdateDateTime)
                .Select(c => new CallLogCommentDto
                {
                    Id = c.Id,
                    CallLogId = c.CallLogId,
                    Comment = c.Comment,
                    CreatedUserId = c.CreatedUserId,
                    CreatedDateTime = c.CreatedDateTime,
                    UpdateUserId = c.UpdateUserId,
                    UpdateUserName = _context.Users.Where(u => u.Id == c.UpdateUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                    UpdateDateTime = c.UpdateDateTime
                })
                .ToListAsync();
        }

        public async Task<CallLogCommentDto> AddCommentAsync(int callLogId, string comment)
        {
            var callComment = new CallLogComment
            {
                CallLogId = callLogId,
                Comment = comment,
                CreatedUserId = _userContext.UserId,
                CreatedDateTime = DateTime.Now,
                UpdateUserId = _userContext.UserId,
                UpdateDateTime = DateTime.Now
            };

            _context.CallLogComments.Add(callComment);
            await _context.SaveChangesAsync();

            return new CallLogCommentDto
            {
                Id = callComment.Id,
                CallLogId = callComment.CallLogId,
                Comment = callComment.Comment,
                CreatedUserId = callComment.CreatedUserId,
                CreatedDateTime = callComment.CreatedDateTime,
                UpdateUserId = callComment.UpdateUserId,
                UpdateUserName = _context.Users.Where(u => u.Id == callComment.UpdateUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                UpdateDateTime = callComment.UpdateDateTime
            };
        }

        public async Task<bool> UpdateCommentAsync(int commentId, string comment)
        {
            var callComment = await _context.CallLogComments.FindAsync(commentId);
            if (callComment == null) return false;

            // Only the writer can update their own comment
            if (callComment.CreatedUserId != _userContext.UserId) return false;

            callComment.Comment = comment;
            callComment.UpdateUserId = _userContext.UserId;
            callComment.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var callComment = await _context.CallLogComments.FindAsync(commentId);
            if (callComment == null) return false;

            // Only comment writer and super admin and admin can delete it
            if (callComment.CreatedUserId != _userContext.UserId && !_userContext.IsAdmin && !_userContext.IsSuperAdmin)
            {
                return false;
            }

            _context.CallLogComments.Remove(callComment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PurposeDto>> GetPurposesAsync()
        {
            return await _context.Purposes
                .Where(p => p.IsActive)
                .Select(p => new PurposeDto { Id = p.ID, PurposeName = p.PurposeName })
                .ToListAsync();
        }
    }
}
