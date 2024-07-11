using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId, bool trackChanges);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
