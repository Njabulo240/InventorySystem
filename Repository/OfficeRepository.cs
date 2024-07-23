using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OfficeRepository : RepositoryBase<Office>, IOfficeRepository
    {
        public OfficeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOffice(Office office)
        {
            Create(office);
        }

        public void DeleteOffice(Office office)
        {
            Delete(office);
        }

        public async Task<IEnumerable<Office>> GetAllOfficesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
              .OrderBy(b => b.Name)
              .Include(e => e.DeviceAssignments)
                  .ThenInclude(d => d.Device)
                      .ThenInclude(dev => dev.Category)
                  .Include(e => e.DeviceAssignments)
                      .ThenInclude(d => d.Device)
                          .ThenInclude(dev => dev.Brand)
              .ToListAsync();
        }

        public async Task<Office> GetOfficeByIdAsync(Guid officeId, bool trackChanges)
        {
            return await FindByCondition(office => office.Id.Equals(officeId), trackChanges)
            .OrderBy(b => b.Name)
              .Include(e => e.DeviceAssignments)
                  .ThenInclude(d => d.Device)
                      .ThenInclude(dev => dev.Category)
                  .Include(e => e.DeviceAssignments)
                      .ThenInclude(d => d.Device)
                          .ThenInclude(dev => dev.Brand)
             .FirstOrDefaultAsync();
        }

        public void UpdateOffice(Office office)
        {
            Update(office);
        }
    }
}