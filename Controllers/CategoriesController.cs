using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCourseSystem.API.DTOs.Category;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly
               ICategoryService _service;

        public CategoriesController(
            ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>
            GetAll()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>
            GetById(int id)
        {
            var result =
                await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>
            Create(
                CreateCategoryDto dto)
        {
            var result =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.ID },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            Update(
                int id,
                UpdateCategoryDto dto)
        {
            var updated =
                await _service.UpdateAsync(
                    id,
                    dto);

            if (!updated)
                return NotFound();

            return Ok(
                new
                {
                    message =
                        "Category Updated Successfully"
                });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>
            Delete(int id)
        {
            var deleted =
                await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok(
                new
                {
                    message =
                        "Category Deleted Successfully"
                });
        }
    }
}
