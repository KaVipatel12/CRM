using System.Collections.Generic;
using System.Threading.Tasks;
using CRM_Api.DTOs;

namespace CRM_Api.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportFieldDto>> GetAvailableFieldsAsync(int? clientType);
        Task<byte[]> GenerateClientDetailsReportAsync(ClientDetailsReportFilter filter);
        Task<byte[]> GenerateFSNotesReportAsync(FSNotesReportFilter filter);
    }
}
