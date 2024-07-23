using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Supplier;

namespace InventrySystem.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public SupplierController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _repository.Supplier.GetAllSuppliersAsync(trackChanges: false);
                _logger.LogInfo("Returned all suppliers from database.");

                var suppliersResult = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
                return Ok(suppliersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSuppliers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "SupplierById")]
        public async Task<IActionResult> GetSupplierById(Guid id)
        {
            try
            {
                var supplier = await _repository.Supplier.GetSupplierByIdAsync(id, trackChanges: false);
                if (supplier == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned supplier with id: {id}");

                var supplierResult = _mapper.Map<SupplierDto>(supplier);
                return Ok(supplierResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupplierById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] SupplierForCreationDto supplier)
        {
            try
            {
                if (supplier == null)
                {
                    _logger.LogError("Supplier object sent from client is null.");
                    return BadRequest("Supplier object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid supplier object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = _mapper.Map<Supplier>(supplier);

                _repository.Supplier.CreateSupplier(supplierEntity);
                _repository.SaveAsync();

                var createdSupplier = _mapper.Map<SupplierDto>(supplierEntity);

                return CreatedAtRoute("SupplierById", new { id = createdSupplier.Id }, createdSupplier);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSupplier action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(Guid id, [FromBody] SupplierForUpdateDto supplier)
        {
            try
            {
                if (supplier == null)
                {
                    _logger.LogError("Supplier object sent from client is null.");
                    return BadRequest("Supplier object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid supplier object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = await _repository.Supplier.GetSupplierByIdAsync(id, trackChanges: true);
                if (supplierEntity == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(supplier, supplierEntity);

                _repository.Supplier.UpdateSupplier(supplierEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSupplier action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            try
            {
                var supplier = await _repository.Supplier.GetSupplierByIdAsync(id, trackChanges: false);
                if (supplier == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Supplier.DeleteSupplier(supplier);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSupplier action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
