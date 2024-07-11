using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Device;

namespace InventrySystem.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DeviceController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            try
            {
                var devices = await _repository.Device.GetAllDevicesAsync(trackChanges: false);
                _logger.LogInfo("Returned all devices from database.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "DeviceById")]
        public async Task<IActionResult> GetDeviceById(Guid id)
        {
            try
            {
                var device = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned device with id: {id}");

                var deviceResult = _mapper.Map<DeviceDto>(device);
                return Ok(deviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceForCreationDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceEntity = _mapper.Map<Device>(device);

                _repository.Device.CreateDevice(deviceEntity);
                _repository.SaveAsync();

                var createdDevice = _mapper.Map<DeviceDto>(deviceEntity);

                return CreatedAtRoute("DeviceById", new { id = createdDevice.Id }, createdDevice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, [FromBody] DeviceForUpdateDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceEntity = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: true);
                if (deviceEntity == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(device, deviceEntity);

                _repository.Device.UpdateDevice(deviceEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(Guid id)
        {
            try
            {
                var device = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Device.DeleteDevice(device);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
