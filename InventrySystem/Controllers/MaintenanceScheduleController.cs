using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.MaintenanceSchedule;

namespace InventrySystem.Controllers
{
    [Route("api/maintenanceschedules")]
    [ApiController]
    public class MaintenanceScheduleController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MaintenanceScheduleController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaintenanceSchedules()
        {
            try
            {
                var maintenanceSchedules = await _repository.MaintenanceSchedule.GetAllMaintenanceSchedulesAsync(trackChanges: false);
                _logger.LogInfo("Returned all maintenance schedules from database.");

                var maintenanceSchedulesResult = _mapper.Map<IEnumerable<MaintenanceScheduleDto>>(maintenanceSchedules);
                return Ok(maintenanceSchedulesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMaintenanceSchedules action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "MaintenanceScheduleById")]
        public async Task<IActionResult> GetMaintenanceScheduleById(Guid id)
        {
            try
            {
                var maintenanceSchedule = await _repository.MaintenanceSchedule.GetMaintenanceScheduleByIdAsync(id, trackChanges: false);
                if (maintenanceSchedule == null)
                {
                    _logger.LogError($"Maintenance schedule with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned maintenance schedule with id: {id}");

                var maintenanceScheduleResult = _mapper.Map<MaintenanceScheduleDto>(maintenanceSchedule);
                return Ok(maintenanceScheduleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMaintenanceScheduleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaintenanceSchedule([FromBody] MaintenanceScheduleForCreationDto maintenanceSchedule)
        {
            try
            {
                if (maintenanceSchedule == null)
                {
                    _logger.LogError("Maintenance schedule object sent from client is null.");
                    return BadRequest("Maintenance schedule object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid maintenance schedule object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var maintenanceScheduleEntity = _mapper.Map<MaintenanceSchedule>(maintenanceSchedule);

                _repository.MaintenanceSchedule.CreateMaintenanceSchedule(maintenanceScheduleEntity);
                _repository.SaveAsync();

                var createdMaintenanceSchedule = _mapper.Map<MaintenanceScheduleDto>(maintenanceScheduleEntity);

                return CreatedAtRoute("MaintenanceScheduleById", new { id = createdMaintenanceSchedule.Id }, createdMaintenanceSchedule);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMaintenanceSchedule action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceSchedule(Guid id, [FromBody] MaintenanceScheduleForUpdateDto maintenanceSchedule)
        {
            try
            {
                if (maintenanceSchedule == null)
                {
                    _logger.LogError("Maintenance schedule object sent from client is null.");
                    return BadRequest("Maintenance schedule object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid maintenance schedule object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var maintenanceScheduleEntity = await _repository.MaintenanceSchedule.GetMaintenanceScheduleByIdAsync(id, trackChanges: true);
                if (maintenanceScheduleEntity == null)
                {
                    _logger.LogError($"Maintenance schedule with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(maintenanceSchedule, maintenanceScheduleEntity);

                _repository.MaintenanceSchedule.UpdateMaintenanceSchedule(maintenanceScheduleEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMaintenanceSchedule action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceSchedule(Guid id)
        {
            try
            {
                var maintenanceSchedule = await _repository.MaintenanceSchedule.GetMaintenanceScheduleByIdAsync(id, trackChanges: false);
                if (maintenanceSchedule == null)
                {
                    _logger.LogError($"Maintenance schedule with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.MaintenanceSchedule.DeleteMaintenanceSchedule(maintenanceSchedule);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMaintenanceSchedule action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
