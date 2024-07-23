using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.DeviceAssignment;

namespace InventrySystem.Controllers
{
    [Route("api/deviceassignments")]
    [ApiController]
    public class DeviceAssignmentController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DeviceAssignmentController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeviceAssignments()
        {
            try
            {
                var deviceAssignments = await _repository.DeviceAssignment.GetAllDeviceAssignmentsAsync(trackChanges: false);
                _logger.LogInfo("Returned all device assignments from database.");

                var deviceAssignmentsResult = _mapper.Map<IEnumerable<DeviceAssignmentDto>>(deviceAssignments);
                return Ok(deviceAssignmentsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDeviceAssignments action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "DeviceAssignmentById")]
        public async Task<IActionResult> GetDeviceAssignmentById(Guid id)
        {
            try
            {
                var deviceAssignment = await _repository.DeviceAssignment.GetDeviceAssignmentByIdAsync(id, trackChanges: false);
                if (deviceAssignment == null)
                {
                    _logger.LogError($"Device assignment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned device assignment with id: {id}");

                var deviceAssignmentResult = _mapper.Map<DeviceAssignmentDto>(deviceAssignment);
                return Ok(deviceAssignmentResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceAssignmentById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeviceAssignment([FromBody] DeviceAssignmentForCreationDto deviceAssignment)
        {
            try
            {
                if (deviceAssignment == null)
                {
                    _logger.LogError("Device assignment object sent from client is null.");
                    return BadRequest("Device assignment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device assignment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceAssignmentEntity = _mapper.Map<DeviceAssignment>(deviceAssignment);

                _repository.DeviceAssignment.CreateDeviceAssignment(deviceAssignmentEntity);
                _repository.SaveAsync();

                var createdDeviceAssignment = _mapper.Map<DeviceAssignmentDto>(deviceAssignmentEntity);

                // update device here
                var device = await _repository.Device.GetDeviceByIdAsync(deviceAssignment.DeviceId, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {deviceAssignment.DeviceId}, hasn't been found in db.");
                    return NotFound("Device not found");
                }

                device.IsAvailable = false;
                _repository.Device.UpdateDevice(device);
                _repository.SaveAsync();



                return CreatedAtRoute("DeviceAssignmentById", new { id = createdDeviceAssignment.Id }, createdDeviceAssignment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDeviceAssignment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("office")]
        public async Task<IActionResult> CreateDeviceAssignmentOffice([FromBody] DeviceAssignmentForOfficeDto deviceAssignment)
        {
            try
            {
                if (deviceAssignment == null)
                {
                    _logger.LogError("Device assignment object sent from client is null.");
                    return BadRequest("Device assignment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device assignment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceAssignmentEntity = _mapper.Map<DeviceAssignment>(deviceAssignment);

                _repository.DeviceAssignment.CreateDeviceAssignment(deviceAssignmentEntity);
                _repository.SaveAsync();

                var createdDeviceAssignment = _mapper.Map<DeviceAssignmentDto>(deviceAssignmentEntity);

                // update device here
                var device = await _repository.Device.GetDeviceByIdAsync(deviceAssignment.DeviceId, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {deviceAssignment.DeviceId}, hasn't been found in db.");
                    return NotFound("Device not found");
                }

                device.IsAvailable = false;
                _repository.Device.UpdateDevice(device);
                _repository.SaveAsync();



                return CreatedAtRoute("DeviceAssignmentById", new { id = createdDeviceAssignment.Id }, createdDeviceAssignment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDeviceAssignment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceAssignment(Guid id, [FromBody] DeviceAssignmentForUpdateDto deviceAssignment)
        {
            try
            {
                if (deviceAssignment == null)
                {
                    _logger.LogError("Device assignment object sent from client is null.");
                    return BadRequest("Device assignment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device assignment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceAssignmentEntity = await _repository.DeviceAssignment.GetDeviceAssignmentByIdAsync(id, trackChanges: true);
                if (deviceAssignmentEntity == null)
                {
                    _logger.LogError($"Device assignment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(deviceAssignment, deviceAssignmentEntity);

                _repository.DeviceAssignment.UpdateDeviceAssignment(deviceAssignmentEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDeviceAssignment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceAssignment(Guid id)
        {
            try
            {
                var deviceAssignment = await _repository.DeviceAssignment.GetDeviceAssignmentByIdAsync(id, trackChanges: false);
                if (deviceAssignment == null)
                {
                    _logger.LogError($"Device assignment with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.DeviceAssignment.DeleteDeviceAssignment(deviceAssignment);
                _repository.SaveAsync();



                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteDeviceAssignment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
