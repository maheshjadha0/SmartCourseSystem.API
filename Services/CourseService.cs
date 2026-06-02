using SmartCourseSystem.API.DTOs.Course;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class CourseService
    : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CourseService(
            ICourseRepository courseRepository,
            ICategoryRepository categoryRepository)
        {
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CourseResponseDto>>
            GetAllAsync()
        {
            var courses =
                await _courseRepository.GetAllAsync();

            return courses.Select(course =>
                new CourseResponseDto
                {
                    ID = course.ID,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    ThumbnailUrl = course.ThumbnailUrl,
                    CategoryName = course.Category.Name,
                    CreatedAt = course.CreatedAt
                });
        }

        public async Task<CourseResponseDto?>
            GetByIdAsync(int id)
        {
            var course =
                await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return null;

            return new CourseResponseDto
            {
                ID = course.ID,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ThumbnailUrl = course.ThumbnailUrl,
                CategoryName = course.Category.Name,
                CreatedAt = course.CreatedAt
            };
        }

        public async Task<CourseResponseDto>
            CreateAsync(CreateCourseDto dto)
        {
            try
            {
                var category =
                    await _categoryRepository
                        .GetByIdAsync(dto.CategoryId);

                if (category == null)
                {
                    throw new Exception(
                        "Category not found");
                }

                var course = new Course
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Price = dto.Price,
                    CategoryId = dto.CategoryId,
                 
                    CreatedBy = 2,
                    CreatedAt = DateTime.UtcNow
                };

                await _courseRepository.AddAsync(course);

                await _courseRepository.SaveChangesAsync();

                return new CourseResponseDto
                {
                    ID = course.ID,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    CategoryName = category.Name,
                    CreatedAt = course.CreatedAt
                };
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error creating course: {ex.Message}",
                    ex);
            }
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                UpdateCourseDto dto)
        {
            var course =
                await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return false;

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.Price = dto.Price;
            course.CategoryId = dto.CategoryId;

            _courseRepository.Update(course);

            await _courseRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var course =
                await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return false;

            _courseRepository.Delete(course);

            await _courseRepository.SaveChangesAsync();

            return true;
        }
    }
}
