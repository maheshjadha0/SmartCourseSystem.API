using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCourseSystem.API.DTOs.Enrollment;
using SmartCourseSystem.API.Services.Interfaces;
using System.Security.Claims;

namespace SmartCourseSystem.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController
        : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentsController(
            IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>
            GetAll()
        {
            return Ok(
                await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult>
            Purchase(
                CreateEnrollmentDto dto)
        {
            int userId =
                int.Parse(
                    User.FindFirst(
                        ClaimTypes.NameIdentifier)!
                    .Value);

            var result =
                await _service
                    .PurchaseCourseAsync(
                        userId,
                        dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>
            Delete(int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok(
                "Enrollment Deleted");
        }
    }
}
