using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventrySystem.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<UserRole> _roleManager;

        public RolesController(RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return BadRequest("Role name cannot be empty");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                return BadRequest("Role already exists");

            var result = await _roleManager.CreateAsync(new UserRole { Name = roleName, DateCreated = DateTime.UtcNow });
            if (!result.Succeeded)
                return BadRequest("Failed to create role");

            return Ok("Role created successfully");
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdateRole(string roleId, [FromBody] string newRoleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound("Role not found");

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                return BadRequest("Failed to update role");

            return Ok("Role updated successfully");
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