using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateReport(Report report)
        {
            Create(report);
        }

        public void DeleteReport(Report report)
        {
            Delete(report);
        }

        public async Task<IEnumerable<Report>> GetAllReports(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<Report> GetReportById(Guid reportId, bool trackChanges)
        {
            return await FindByCondition(r => r.Id.Equals(reportId), trackChanges)
            .FirstOrDefaultAsync();
        }

        public void UpdateReport(Report report)
        {
            Update(report);
        }
    }
}
