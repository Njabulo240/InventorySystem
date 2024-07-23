using Contracts;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.User;

namespace InventrySystem.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly RoleManager<UserRole> _roleManager;

        public RolesController(ILoggerManager logger, RoleManager<UserRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] UserRoleForCreationDto roleDto)
        {
            try
            {
                if (roleDto == null || string.IsNullOrEmpty(roleDto.Name))
                {
                    _logger.LogError("Role object sent from client is null or empty.");
                    return BadRequest("Role name cannot be empty");
                }

                var roleExists = await _roleManager.RoleExistsAsync(roleDto.Name);
                if (roleExists)
                {
                    _logger.LogError($"Role with name: {roleDto.Name} already exists.");
                    return BadRequest("Role already exists");
                }

                var result = await _roleManager.CreateAsync(new UserRole { Name = roleDto.Name, DateCreated = DateTime.UtcNow });
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to create role.");
                    return BadRequest("Failed to create role");
                }

                var createdRole = await _roleManager.FindByNameAsync(roleDto.Name);
                return Ok(new { message = "Role created successfully", role = createdRole });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdateRole(string roleId, [FromBody] UserRoleForCreationDto roleDto)
        {
            try
            {
                if (roleDto == null || string.IsNullOrEmpty(roleDto.Name))
                {
                    _logger.LogError("Role object sent from client is null or empty.");
                    return BadRequest("Role name cannot be empty");
                }

                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {roleId}, hasn't been found in db.");
                    return NotFound("Role not found");
                }

                role.Name = roleDto.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to update role.");
                    return BadRequest("Failed to update role");
                }
                return Ok(new { message = "Role updated successfully" }); // Return a success message
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to delete role.");
                    return BadRequest("Failed to delete role");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
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
                    return NotFound("Role not found");
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRoleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}