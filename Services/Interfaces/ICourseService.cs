using SmartCourseSystem.API.DTOs.Course;

namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDto>>
            GetAllAsync();

        Task<CourseResponseDto?>
            GetByIdAsync(int id);

        Task<CourseResponseDto>
            CreateAsync(CreateCourseDto dto);

        Task<bool>
            UpdateAsync(
                int id,
                UpdateCourseDto dto);

        Task<bool>
            DeleteAsync(int id);
    }
}
