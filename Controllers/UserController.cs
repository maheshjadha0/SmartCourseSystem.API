using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("students")]
        public async Task<IActionResult>
            GetStudents()
        {
            var students =
                await _userService
                .GetStudentsAsync();

            return Ok(students);
        }
    }
}
