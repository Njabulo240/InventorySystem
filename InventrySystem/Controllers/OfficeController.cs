using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Office;

namespace InventrySystem.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OfficeController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOffices()
        {
            try
            {
                var offices = await _repository.Office.GetAllOfficesAsync(trackChanges: false);
                _logger.LogInfo("Returned all offices from database.");

                var officesResult = _mapper.Map<IEnumerable<OfficeDto>>(offices);
                return Ok(officesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOffices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OfficeById")]
        public async Task<IActionResult> GetOfficeById(Guid id)
        {
            try
            {
                var office = await _repository.Office.GetOfficeByIdAsync(id, trackChanges: false);
                if (office == null)
                {
                    _logger.LogError($"Office with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned office with id: {id}");

                var officeResult = _mapper.Map<OfficeDto>(office);
                return Ok(officeResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOfficeById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOffice([FromBody] OfficeForCreationDto office)
        {
            try
            {
                if (office == null)
                {
                    _logger.LogError("Office object sent from client is null.");
                    return BadRequest("Office object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid office object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var officeEntity = _mapper.Map<Office>(office);

                _repository.Office.CreateOffice(officeEntity);
                _repository.SaveAsync();

                var createdOffice = _mapper.Map<OfficeDto>(officeEntity);

                return CreatedAtRoute("OfficeById", new { id = createdOffice.Id }, createdOffice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOffice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOffice(Guid id, [FromBody] OfficeForUpdateDto office)
        {
            try
            {
                if (office == null)
                {
                    _logger.LogError("Office object sent from client is null.");
                    return BadRequest("Office object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid office object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var officeEntity = await _repository.Office.GetOfficeByIdAsync(id, trackChanges: true);
                if (officeEntity == null)
                {
                    _logger.LogError($"Office with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(office, officeEntity);

                _repository.Office.UpdateOffice(officeEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOffice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(Guid id)
        {
            try
            {
                var office = await _repository.Office.GetOfficeByIdAsync(id, trackChanges: false);
                if (office == null)
                {
                    _logger.LogError($"Office with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Office.DeleteOffice(office);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOffice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
