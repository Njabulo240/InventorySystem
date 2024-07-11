using AutoMapper;
using Contracts;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.User;

namespace InventrySystem.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

                foreach (var userDto in userDtos)
                {
                    var user = await _userManager.FindByIdAsync(userDto.Id);
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Roles = roles;
                }

                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"User with id: {userId}, hasn't been found in db.");
                    return NotFound();
                }

                var userDto = _mapper.Map<UserDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Roles = roles;

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserForUpdateDto updatedUser)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"User with id: {userId}, hasn't been found in db.");
                    return NotFound();
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                var userDto = _mapper.Map(updatedUser, user);
                var result = await _userManager.UpdateAsync(userDto);

                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to update user.");
                    return BadRequest("Failed to update user.");
                }

                await _userManager.AddToRolesAsync(user, updatedUser.Roles);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"User with id: {userId}, hasn't been found in db.");
                    return NotFound();
                }

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to delete user.");
                    return BadRequest("Failed to delete user.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
