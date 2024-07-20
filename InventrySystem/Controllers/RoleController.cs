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
        private ILoggerManager _logger;
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
                return Ok("Role created successfully");
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
                return Ok("Role updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound("Role not found");

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return BadRequest("Failed to delete role");

            return Ok("Role deleted successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
    }
}