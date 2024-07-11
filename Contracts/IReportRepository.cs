using Entities.Models;

namespace Contracts
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReports(bool trackChanges);
        Task<Report> GetReportById(Guid reportId, bool trackChanges);
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(Report report);
    }
}
