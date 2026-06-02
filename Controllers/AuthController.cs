using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCourseSystem.API.DTOs;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(
            IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterDto dto)
        {
            try
            {
                var result =
                    await _service.RegisterAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while adding user: {ex.Message}", ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            var result =
                await _service.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized(
                    "Invalid email or password");
            }

            return Ok(result);
        }
    }
}
