using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repoContext;
        private IDeviceRepository _device;
        private ICategoryRepository _category;
        private IBrandRepository _brand;
        private ISupplierRepository _supplier;
        private IEmployeeRepository _employee;
        private IOfficeRepository _office;
        private IDeviceAssignmentRepository _deviceAssignment;
        private IMaintenanceScheduleRepository _maintenanceSchedule;
        private IServiceHistoryRepository _serviceHistory;


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IDeviceRepository Device
        {
            get
            {
                if (_device == null)
                {
                    _device = new DeviceRepository(_repoContext);
                }

                return _device;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        public IBrandRepository Brand
        {
            get
            {
                if (_brand == null)
                {
                    _brand = new BrandRepository(_repoContext);
                }

                return _brand;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_repoContext);
                }

                return _supplier;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
            }
        }

        public IOfficeRepository Office
        {
            get
            {
                if (_office == null)
                {
                    _office = new OfficeRepository(_repoContext);
                }

                return _office;
            }
        }


        public IDeviceAssignmentRepository DeviceAssignment
        {
            get
            {
                if (_deviceAssignment == null)
                {
                    _deviceAssignment = new DeviceAssignmentRepository(_repoContext);
                }

                return _deviceAssignment;
            }
        }

        public IMaintenanceScheduleRepository MaintenanceSchedule
        {
            get
            {
                if (_maintenanceSchedule == null)
                {
                    _maintenanceSchedule = new MaintenanceScheduleRepository(_repoContext);
                }

                return _maintenanceSchedule;
            }
        }

        public IServiceHistoryRepository ServiceHistory
        {
            get
            {
                if (_serviceHistory == null)
                {
                    _serviceHistory = new ServiceHistoryRepository(_repoContext);
                }

                return _serviceHistory;
            }
        }


        public void SaveAsync() => _repoContext.SaveChanges();
    }
}
