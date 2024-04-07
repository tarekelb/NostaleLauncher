using Microsoft.AspNetCore.Mvc;
using NostaleLauncher.API.Services;
using NostaleLauncher.Domain.Entities;
using NostaleLauncher.Domain.Interfaces;

namespace NostaleLauncher.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;
        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var result = await _authService.ValidateUserAsync(user.Username, user.Password);
            if (!result)
                return Unauthorized();

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await _authService.RegisterUserAsync(user.Username, user.Password);
            if (!result)
                return Conflict();

            return Ok();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok();
        }


    }
}
