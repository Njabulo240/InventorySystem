using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Brand;

namespace InventrySystem.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BrandController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await _repository.Brand.GetAllBrandsAsync(trackChanges: false);
                _logger.LogInfo("Returned all brands from database.");

                var brandsResult = _mapper.Map<IEnumerable<BrandDto>>(brands);
                return Ok(brandsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllBrands action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "BrandById")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            try
            {
                var brand = await _repository.Brand.GetBrandByIdAsync(id, trackChanges: false);
                if (brand == null)
                {
                    _logger.LogError($"Brand with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned brand with id: {id}");

                var brandResult = _mapper.Map<BrandDto>(brand);
                return Ok(brandResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBrandById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateBrand([FromBody] BrandForCreationDto brand)
        {
            try
            {
                if (brand == null)
                {
                    _logger.LogError("Brand object sent from client is null.");
                    return BadRequest("Brand object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid brand object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var brandEntity = _mapper.Map<Brand>(brand);

                _repository.Brand.CreateBrand(brandEntity);
                _repository.SaveAsync();

                var createdBrand = _mapper.Map<BrandDto>(brandEntity);

                return CreatedAtRoute("BrandById", new { id = createdBrand.Id }, createdBrand);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBrand action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] BrandForUpdateDto brand)
        {
            try
            {
                if (brand == null)
                {
                    _logger.LogError("Brand object sent from client is null.");
                    return BadRequest("Brand object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid brand object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var brandEntity = await _repository.Brand.GetBrandByIdAsync(id, trackChanges: true);
                if (brandEntity == null)
                {
                    _logger.LogError($"Brand with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(brand, brandEntity);

                _repository.Brand.UpdateBrand(brandEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBrand action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            try
            {
                var brand = await _repository.Brand.GetBrandByIdAsync(id, trackChanges: false);
                if (brand == null)
                {
                    _logger.LogError($"Brand with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Brand.DeleteBrand(brand);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBrand action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
