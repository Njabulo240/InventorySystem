using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Category;

namespace InventrySystem.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CategoryController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges: false);
                _logger.LogInfo("Returned all categories from database.");

                var categoriesResult = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return Ok(categoriesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCategories action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _repository.Category.GetCategoryByIdAsync(id, trackChanges: false);
                if (category == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned category with id: {id}");

                var categoryResult = _mapper.Map<CategoryDto>(category);
                return Ok(categoryResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCategoryById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryForCreationDto category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = _mapper.Map<Category>(category);

                _repository.Category.CreateCategory(categoryEntity);
                _repository.SaveAsync();

                var createdCategory = _mapper.Map<CategoryDto>(categoryEntity);

                return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
        {
            try
            {
                if (category == null)
                {
                    _logger.LogError("Category object sent from client is null.");
                    return BadRequest("Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = await _repository.Category.GetCategoryByIdAsync(id, trackChanges: true);
                if (categoryEntity == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(category, categoryEntity);

                _repository.Category.UpdateCategory(categoryEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var category = await _repository.Category.GetCategoryByIdAsync(id, trackChanges: false);
                if (category == null)
                {
                    _logger.LogError($"Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Category.DeleteCategory(category);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
