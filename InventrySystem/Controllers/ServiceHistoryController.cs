using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.ServiceHistory;

namespace InventrySystem.Controllers
{
    [Route("api/servicehistories")]
    [ApiController]
    public class ServiceHistoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ServiceHistoryController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceHistories()
        {
            try
            {
                var serviceHistories = await _repository.ServiceHistory.GetAllServiceHistoriesAsync(trackChanges: false);
                _logger.LogInfo("Returned all service histories from database.");

                var serviceHistoriesResult = _mapper.Map<IEnumerable<ServiceHistoryDto>>(serviceHistories);
                return Ok(serviceHistoriesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllServiceHistories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ServiceHistoryById")]
        public async Task<IActionResult> GetServiceHistoryById(Guid id)
        {
            try
            {
                var serviceHistory = await _repository.ServiceHistory.GetServiceHistoryByIdAsync(id, trackChanges: false);
                if (serviceHistory == null)
                {
                    _logger.LogError($"Service history with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned service history with id: {id}");

                var serviceHistoryResult = _mapper.Map<ServiceHistoryDto>(serviceHistory);
                return Ok(serviceHistoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetServiceHistoryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceHistory([FromBody] ServiceHistoryForCreationDto serviceHistory)
        {
            try
            {
                if (serviceHistory == null)
                {
                    _logger.LogError("Service history object sent from client is null.");
                    return BadRequest("Service history object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid service history object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var serviceHistoryEntity = _mapper.Map<ServiceHistory>(serviceHistory);

                _repository.ServiceHistory.CreateServiceHistory(serviceHistoryEntity);
                _repository.SaveAsync();

                var createdServiceHistory = _mapper.Map<ServiceHistoryDto>(serviceHistoryEntity);

                return CreatedAtRoute("ServiceHistoryById", new { id = createdServiceHistory.Id }, createdServiceHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateServiceHistory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceHistory(Guid id, [FromBody] ServiceHistoryForUpdateDto serviceHistory)
        {
            try
            {
                if (serviceHistory == null)
                {
                    _logger.LogError("Service history object sent from client is null.");
                    return BadRequest("Service history object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid service history object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var serviceHistoryEntity = await _repository.ServiceHistory.GetServiceHistoryByIdAsync(id, trackChanges: true);
                if (serviceHistoryEntity == null)
                {
                    _logger.LogError($"Service history with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(serviceHistory, serviceHistoryEntity);

                _repository.ServiceHistory.UpdateServiceHistory(serviceHistoryEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateServiceHistory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceHistory(Guid id)
        {
            try
            {
                var serviceHistory = await _repository.ServiceHistory.GetServiceHistoryByIdAsync(id, trackChanges: false);
                if (serviceHistory == null)
                {
                    _logger.LogError($"Service history with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.ServiceHistory.DeleteServiceHistory(serviceHistory);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteServiceHistory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
