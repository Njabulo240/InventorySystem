using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Employee;

namespace InventrySystem.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _repository.Employee.GetAllEmployeesAsync(trackChanges: false);
                _logger.LogInfo("Returned all employees from database.");

                var employeesResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployees action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployeeByIdAsync(id, trackChanges: false);
                if (employee == null)
                {
                    _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned employee with id: {id}");

                var employeeResult = _mapper.Map<EmployeeDto>(employee);
                return Ok(employeeResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("Employee object sent from client is null.");
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _mapper.Map<Employee>(employee);

                _repository.Employee.CreateEmployee(employeeEntity);
                _repository.SaveAsync();

                var createdEmployee = _mapper.Map<EmployeeDto>(employeeEntity);

                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("Employee object sent from client is null.");
                    return BadRequest("Employee object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = await _repository.Employee.GetEmployeeByIdAsync(id, trackChanges: true);
                if (employeeEntity == null)
                {
                    _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(employee, employeeEntity);

                _repository.Employee.UpdateEmployee(employeeEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployeeByIdAsync(id, trackChanges: false);
                if (employee == null)
                {
                    _logger.LogError($"Employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Employee.DeleteEmployee(employee);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
