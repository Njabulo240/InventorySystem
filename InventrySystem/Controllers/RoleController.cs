using AutoMapper;
using Contracts;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.User;

namespace InventrySystem.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly RoleManager<UserRole> _roleManager;

        public RoleController(ILoggerManager logger, IMapper mapper, RoleManager<UserRole> roleManager)
        {
            _logger = logger;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] UserRoleForCreationDto addRole)
        {
            try
            {
                var role = _mapper.Map<UserRole>(addRole);
                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to create role.");
                    return BadRequest("Failed to create role.");
                }

                return Ok("Role created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> EditRole(string roleId, [FromBody] UserRoleForUpdateDto roleUpdate)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {roleId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(roleUpdate, role);
                var result = await _roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to update role.");
                    return BadRequest("Failed to update role.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EditRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                var rolesDto = _mapper.Map<IEnumerable<UserRoleDto>>(roles);

                return Ok(rolesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllRoles action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {roleId}, hasn't been found in db.");
                    return NotFound();
                }

                var roleDto = _mapper.Map<UserRoleDto>(role);
                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRoleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {roleId}, hasn't been found in db.");
                    return NotFound();
                }

                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to delete role.");
                    return BadRequest("Failed to delete role.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
