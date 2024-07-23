using AutoMapper;
using EmailService;
using Entities.Identity;
using InventrySystem.JwtFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.User;

namespace InventrySystem.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly IEmailSender _emailSender;

        public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _emailSender = emailSender;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, "User");

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            if (!await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                await _userManager.AccessFailedAsync(user);

                if (await _userManager.IsLockedOutAsync(user))
                {
                    var content = $@"Your account is locked out. To reset the password click this link: {userForAuthentication.ClientURI}";
                    var message = new Message(new string[] { userForAuthentication.Email },
                        "Locked out account information", content, null);

                    await _emailSender.SendEmailAsync(message);

                    return Unauthorized(new AuthResponseDto { ErrorMessage = "The account is locked out" });
                }

                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }

            var token = await _jwtHandler.GenerateToken(user);

            await _userManager.ResetAccessFailedCountAsync(user);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", forgotPasswordDto.Email }
            };

            var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);

            await _emailSender.SendEmailAsync(message);

            return Ok();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);

                return BadRequest(new { Errors = errors });
            }

            await _userManager.SetLockoutEndDateAsync(user, new DateTime(2000, 1, 1));

            return Ok();
        }

        [HttpGet("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("Invalid Email Confirmation Request");

            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                return BadRequest("Invalid Email Confirmation Request");

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
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
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}", Name = "UserById")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { Message = $"User with ID {id} not found." });
                }

                var userDto = _mapper.Map<UserDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Roles = roles;

                return Ok(userDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserForUpdateDto updatedUser)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { Message = $"User with ID {id} not found." });
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);

                var userDto = _mapper.Map(updatedUser, user);
                var result = await _userManager.UpdateAsync(userDto);

                if (result.Succeeded)
                {
                    await _userManager.AddToRolesAsync(user, updatedUser.Roles);
                    return NoContent();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { Message = $"User with ID {id} not found." });
                }

                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return NoContent();
                }

                return BadRequest(result.Errors);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
